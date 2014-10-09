// USBDevice.cpp: implementation of the USBDevice class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "UsbKey.h"
#include "USBDevice.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

USBDevice::USBDevice()
{

}

USBDevice::~USBDevice()
{

}

BOOL USBDevice::SearchDevice()
{
	
	char        HCName[16];   //USB控制器名
    int         HCNum;        //序号 
    PCHAR       rootHubName;  //USB Hub名
	ULONG       index;        //端口
    BOOL        success;      //是否成功
    HANDLE hHCDev;            //USB控制器设备句柄
	HANDLE hHubDevice;        //USB Hub设备句柄
    PUSB_NODE_CONNECTION_INFORMATION    connectionInfo;//要求取得关于USB端口和连接设备信息
	

	for (HCNum = 0; HCNum < NUM_HCS_TO_CHECK; HCNum++)//设备查询
    {   
		//AfxMessageBox("hehe！！！",0,0);
        wsprintf(HCName, "\\\\.\\HCD%d", HCNum);//字符串格式化函数wsprintf(缓冲区,格式,要格式化的值); 
        hHCDev = CreateFile(HCName,
                            GENERIC_WRITE,
                            FILE_SHARE_WRITE,
                            NULL,
                            OPEN_EXISTING,
                            0,
                            NULL);  //同过控制器名打开
		if (hHCDev == INVALID_HANDLE_VALUE)
        {    
			//AfxMessageBox("没有找到USB控制器！！！",0,0);
		    continue;
		}

		ULONG           nBytes;

        rootHubName =(char*) GetRootHubName(hHCDev);//获得Hub名
		//AfxMessageBox("rootHub！！！",0,0);
		if(rootHubName==NULL)
		{    
			//AfxMessageBox("rootHub出错！！！",0,0);
			continue;
		}

		 PUSB_NODE_INFORMATION HubInfo;//The USB_NODE_INFORMATION structure is used with the IOCTL_USB_GET_NODE_INFORMATION I/O control request to retrieve information about a parent device.USB终端信息
         HubInfo = (PUSB_NODE_INFORMATION)malloc(sizeof(USB_NODE_INFORMATION));//申请数据空间
		 PCHAR deviceName;
		 deviceName = (PCHAR)malloc(strlen(rootHubName) + sizeof("\\\\.\\"));//申请设备名空间
         if (rootHubName != NULL)
         {
			strcpy(deviceName, "\\\\.\\");
			strcpy(deviceName + sizeof("\\\\.\\") - 1, rootHubName);
			hHubDevice = CreateFile(deviceName,
                            GENERIC_WRITE,
                            FILE_SHARE_WRITE,
                            NULL,
                            OPEN_EXISTING,
                            0,
                            NULL);//同过设备名打开Hub获得连接信息
			free(deviceName);
			if (hHubDevice == INVALID_HANDLE_VALUE)
			{
				//AfxMessageBox("获得设备句柄失败！！！",0,0);	
				continue;
			}
			success = DeviceIoControl(hHubDevice,
                              IOCTL_USB_GET_NODE_INFORMATION,
                              HubInfo,
                              sizeof(USB_NODE_INFORMATION),
                              HubInfo,
                              sizeof(USB_NODE_INFORMATION),
                              &nBytes,
                              NULL);//获得Hub上的端口和连接的设备信息
			if (!success)
			{
				//AfxMessageBox("获得USB设备属性失败!!!",0,0);
				continue;
			}

		 }
		 	
		 int port;//端口数
		 port=HubInfo->u.HubInformation.HubDescriptor.bNumberOfPorts;
		 for (index=1; index <= port; index++)
		 {
			 ULONG nBytes;
			 nBytes = sizeof(USB_NODE_CONNECTION_INFORMATION) +
                sizeof(USB_PIPE_INFO) * 30;//获得连接信息
			 connectionInfo = (PUSB_NODE_CONNECTION_INFORMATION)malloc(nBytes);
			 if (connectionInfo == NULL)
			 {
				 //AfxMessageBox("申请空间出错!!!",0,0);
				 continue;
			 }
			 connectionInfo->ConnectionIndex = index;
			 success = DeviceIoControl(hHubDevice,
                                  IOCTL_USB_GET_NODE_CONNECTION_INFORMATION,
                                  connectionInfo,
                                  nBytes,
                                  connectionInfo,
                                  nBytes,
                                  &nBytes,
                                  NULL);//获得port[index]的信息
			 if (!success)
			 {
				 free(connectionInfo);
				 //AfxMessageBox("获得端口信息出错!!!",0,0);
				 continue;
			 }
			 if(connectionInfo)
	         if (connectionInfo->ConnectionStatus == DeviceConnected)
			 {
			      if(UsbKeyCheck(connectionInfo))
				  {
				       CloseHandle(hHubDevice);
				       CloseHandle(hHCDev);
				       return TRUE;
				  }
			      else
				       continue;
			 }
		 }

      }
	 			
//////////////////////////////////////////////////////////////////////////////
///////如果用HID设备的USB接口做KEY就用以下代码！！              //////////////
//////////////////////////////////////////////////////////////////////////////



	/*SP_DEVICE_INTERFACE_DATA devInfoData;  //设备信息
	PSP_DEVICE_INTERFACE_DETAIL_DATA pDetail;
	_HIDD_ATTRIBUTES hidAttributes;//设备属性识别码结构体
	HANDLE hidHandle;
	int nCount;
	BOOL bResult;
	HDEVINFO hDevInfo;
	GUID guid;

	//获得HID设备类的GUID
	HidD_GetHidGuid(&guid);

	//获得设备信息集句柄
	hDevInfo=::SetupDiGetClassDevs(&guid,NULL,NULL,DIGCF_PRESENT|DIGCF_DEVICEINTERFACE);//建立设备信息表的控制选项DIGCF_PRESENT只列出当前存在的设备信息
	if(hDevInfo==INVALID_HANDLE_VALUE)//如失败则返回INVALID_HANDLE_VALUE
	{
		AfxMessageBox("没有找到设备类！！",0,0);
		return FALSE;
	}

	//申请设备接口数据空间
	devInfoData.cbSize=sizeof(SP_DEVICE_INTERFACE_DATA);

	nCount=0;

	::SetLastError(NO_ERROR);// 防止错误冲突
	bResult=TRUE;

	//设备序号=0，1，2，3......逐一检测设备接口到失败为止、
	while(::GetLastError()!=ERROR_NO_MORE_ITEMS)
	{

		//枚举符合该GUID的设备接口
		bResult=::SetupDiEnumDeviceInterfaces(
			hDevInfo,     //设备信息句柄
			NULL,         //不需要额外的设备描述
			&guid,         //GUID
			(ULONG)nCount, //设备信息集里的设备序号
			&devInfoData);  //设备接口信息

		if(bResult)
		{

			ULONG requiredLength=0;
			 //获得所需信息长度 requireLength
			SetupDiGetInterfaceDeviceDetail(
				hDevInfo,    //设备信息集句柄
				&devInfoData, //设备接口信息
				NULL,        //为NULL表示不用来获得设备信息，
				             //而来获得信息长度
				0,           //输出缓冲区大小
				&requiredLength,    //计算输出缓冲区大小
				NULL);        //不需要额外的设备描述
			pDetail=(PSP_DEVICE_INTERFACE_DETAIL_DATA)::GlobalAlloc(LMEM_ZEROINIT,INTERFACE_DETAIL_SIZE);//该函数用于从全局堆中分配出内存供程序使用。LMEM_ZEROINIT内存初始化为零，分配INTERFACE_DETAIL_DATA个字节。
			pDetail->cbSize=sizeof(SP_DEVICE_INTERFACE_DETAIL_DATA);


			if(!SetupDiGetInterfaceDeviceDetail(
				hDevInfo,    //设备信息集句柄
				&devInfoData, //设备接口信息
				pDetail,       //设备接口细节
				requiredLength, //计算输出缓冲区大小
				NULL,       //不用获得设备信息
				NULL      //不用额外的设备描述
				))
			{
				AfxMessageBox("获得设备细节信息失败！！！",0,0);
				free(pDetail);
				nCount++;
				continue;
			}
			AfxMessageBox(pDetail->DevicePath,0,0);
			hidHandle=CreateFile(pDetail->DevicePath,
				                GENERIC_READ|GENERIC_WRITE,
								FILE_SHARE_READ|FILE_SHARE_WRITE,
			                    NULL,OPEN_EXISTING,               //新建文件，文件不存在时定义为OPEN_EXISTING
								FILE_FLAG_OVERLAPPED,NULL);//失败返回INVALID_HANDLE_VALUE
			if(hidHandle==INVALID_HANDLE_VALUE)
			{
				AfxMessageBox("获得设备句柄失败！！！",0,0);
				//return FALSE;
				nCount++;
				continue;
			}
			if(!HidD_GetAttributes(hidHandle,&hidAttributes))//获得USB设备属性
			{
				AfxMessageBox("获得USB设备属性失败!!!",0,0);
				CloseHandle(hidHandle);
				//return FALSE;
				nCount++;
				continue;
			}
			if(hidAttributes.VendorID==0x1241&&
			   hidAttributes.ProductID==0x1503&&
			   hidAttributes.VersionNumber==0x290)//判断该USB设备的信息是否与你的Key相等
			{	AfxMessageBox("xxx",0,0);
				return TRUE;
			}
			CloseHandle(hidHandle);
			nCount++;

		}
	}*/
	CloseHandle(hHubDevice);
	CloseHandle(hHCDev);
	//AfxMessageBox("没有找到正确的USB KEY!!!",0,0);
	return FALSE;

}

PCHAR USBDevice::GetRootHubName(HANDLE HostController)
{  // AfxMessageBox("进入GETHub！！！",0,0);
	BOOL                success;
    ULONG               nBytes;
    USB_ROOT_HUB_NAME   rootHubName;
    PUSB_ROOT_HUB_NAME  rootHubNameW;
    PCHAR               rootHubNameA;

    rootHubNameW = NULL;
    rootHubNameA = NULL;

   success = DeviceIoControl(HostController,
                              IOCTL_USB_GET_ROOT_HUB_NAME,
                              0,
                              0,
                              &rootHubName,
                              sizeof(rootHubName),
                              &nBytes,
                              NULL);

    if (!success)
    {   //AfxMessageBox("不成功！！！",0,0);
        goto GetRootHubNameError;
    }

    nBytes = rootHubName.ActualLength;

    rootHubNameW =(PUSB_ROOT_HUB_NAME) malloc(nBytes);

    if (rootHubNameW == NULL)
    {

        goto GetRootHubNameError;
    }

    success = DeviceIoControl(HostController,
                              IOCTL_USB_GET_ROOT_HUB_NAME,
                              NULL,
                              0,
                              rootHubNameW,
                              nBytes,
                              &nBytes,
                              NULL);

    if (!success)
    {
       goto GetRootHubNameError;
    }

    rootHubNameA = WideStrToMultiStr(rootHubNameW->RootHubName);
    free(rootHubNameW);

    return rootHubNameA;


GetRootHubNameError:
    if (rootHubNameW != NULL)
    {
        free(rootHubNameW);
        rootHubNameW = NULL;
		//AfxMessageBox("出错！！！",0,0);
    }

    return NULL;

}

PCHAR USBDevice::WideStrToMultiStr(PWCHAR WideStr)
{
	ULONG nBytes;
    PCHAR MultiStr;
    nBytes = WideCharToMultiByte(
                 CP_ACP, // code page
                 0,      // performance and mapping flags
                 WideStr,// address of wide-character string
                 -1,     // number of characters in string
                 NULL,   // address of buffer for new string

                 0,      // size of buffer

                 NULL,   // address of default for unmappable 
                         // characters

                 NULL    // address of flag set when default 
                             // char. used

				 );  

    if (nBytes == 0)
    {
        return NULL;
    }
    MultiStr =(PCHAR) malloc(nBytes);

    if (MultiStr == NULL)
    {
        return NULL;
    }
    nBytes = WideCharToMultiByte(
                 CP_ACP,
                 0,
                 WideStr,
                 -1,
                 MultiStr,
                 nBytes,
                 NULL,
                 NULL);

    if (nBytes == 0)
    {
        free(MultiStr);
        return NULL;
    }

    return MultiStr;

}

BOOL USBDevice::UsbKeyCheck(PUSB_NODE_CONNECTION_INFORMATION connectionInfo)//USBKEY数据验证
{
	 if(connectionInfo->DeviceDescriptor.idVendor==0x781&&
	 connectionInfo->DeviceDescriptor.idProduct==0x5530&&
	 connectionInfo->DeviceDescriptor.iManufacturer==0x1&&
	 connectionInfo->DeviceDescriptor.iSerialNumber==0x3)////判断该USB设备的信息是否与你的Key相等
	 {
	     //AfxMessageBox("搜索到正确的USB KEY!!!",0,0);
	     return TRUE;
	 }
     else
         return FALSE;
}
