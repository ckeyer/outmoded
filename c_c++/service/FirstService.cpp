#include <windows.h>
#include <stdio.h>
#include <time.h>
#include "conio.h"
#define SERVICENAME ("FirstService")
#define LOGFILE "H:\\WCJ\\service\\日志.TXT"
#define SLEEP_TIME 3000 

SERVICE_STATUS          ServiceStatus;
SERVICE_STATUS_HANDLE   hStatus;

void  ServiceMain(int argc, char** argv);
void  ControlHandler(DWORD request);
int InitService();
void smain();
int WriteToLog(char *str);

void smain()
{
	struct tm *stm1;
	time_t tm1;
	FILE *fp;
	fp=fopen(LOGFILE,"a+");
	tm1=time(NULL);
	stm1=localtime(&tm1);
	fprintf(fp,"%4d/%d/%d  %2d.%2d.%02d\n",stm1->tm_year+1900,stm1->tm_mon+1,stm1->tm_mday,stm1->tm_hour,stm1->tm_min,stm1->tm_sec);
	if(0 == stm1->tm_sec % 5)
	{	
		fprintf(fp,"五，过\n")	;
		ShellExecute(NULL,"open",LOGFILE,NULL,NULL,SW_SHOWNORMAL);
	}
	fclose(fp);
	
}

int WriteToLog(char *str)
{
	FILE *log;
	log=fopen(LOGFILE,"a+");
	if(log==NULL)
	{
		return -1;
	}
	fprintf(log,"$$$$$$$%s$$$$$$$\n",str);
	fclose(log);
	return 0;
} 

void ControlHandler(DWORD request)
{
   switch(request)
   {
      case SERVICE_CONTROL_STOP:
         ServiceStatus.dwWin32ExitCode = 0;
         ServiceStatus.dwCurrentState = SERVICE_STOPPED;
         SetServiceStatus (hStatus, &ServiceStatus);
         return;
      case SERVICE_CONTROL_SHUTDOWN:
         ServiceStatus.dwWin32ExitCode = 0;
         ServiceStatus.dwCurrentState = SERVICE_STOPPED;
         SetServiceStatus (hStatus, &ServiceStatus);
         return;
      default:
         break;
    }

    SetServiceStatus (hStatus, &ServiceStatus);
    return;
}

int InitService()
{
	int result ;
	result=WriteToLog("服务日志启动");
	return result;
}

void ServiceMain(int argc, char** argv)
{
   int error;
	error=InitService();
	if(error)
	{
		ServiceStatus.dwCurrentState=SERVICE_STOPPED;
		ServiceStatus.dwWin32ExitCode= -1;
		SetServiceStatus(hStatus,&ServiceStatus);
		return ;
	}
   ServiceStatus.dwServiceType =
      SERVICE_WIN32;
   ServiceStatus.dwCurrentState =
      SERVICE_START_PENDING;
   ServiceStatus.dwControlsAccepted   = 
      SERVICE_ACCEPT_STOP |
      SERVICE_ACCEPT_SHUTDOWN;
   ServiceStatus.dwWin32ExitCode = 0;
   ServiceStatus.dwServiceSpecificExitCode = 0;
   ServiceStatus.dwCheckPoint = 0;
   ServiceStatus.dwWaitHint = 0;

   hStatus = RegisterServiceCtrlHandler(
      SERVICENAME,
      (LPHANDLER_FUNCTION)ControlHandler);
   if (hStatus == (SERVICE_STATUS_HANDLE)0)
   {
      return;
   } 

   //InitService();

   ServiceStatus.dwCurrentState =
      SERVICE_RUNNING;
   SetServiceStatus (hStatus, &ServiceStatus);

   while (ServiceStatus.dwCurrentState ==
          SERVICE_RUNNING)
   {
      Sleep(SLEEP_TIME);
   SYSTEMTIME aTime;
   ::GetLocalTime(&aTime);
   {
    //WriteToLog("hello,service");
    smain();
   }
   }
   return;
}

int  main(int argc, char* argv[])
{
   SERVICE_TABLE_ENTRY ServiceTable[2];
   ServiceTable[0].lpServiceName = SERVICENAME;
   ServiceTable[0].lpServiceProc = (LPSERVICE_MAIN_FUNCTION)ServiceMain;
   
   ServiceTable[1].lpServiceName = NULL;
   ServiceTable[1].lpServiceProc = NULL;
   StartServiceCtrlDispatcher(ServiceTable);
   	struct tm *stm1;
	time_t tm1;
	FILE *fp;
	fp=fopen(LOGFILE,"a+");
	tm1=time(NULL);
	stm1=localtime(&tm1);
	fprintf(fp,"%4d/%d/%d  %2d.%2d.%02d\n",stm1->tm_year+1900,stm1->tm_mon+1,stm1->tm_mday,stm1->tm_hour,stm1->tm_min,stm1->tm_sec);
	fclose(fp);
   printf("自动安装？\n");
   if(getch()=='y') 
   {
   	printf("自动安装中\n");
   	system("sc delete FirstService");
   	system("sc create FirstService binpath= H:\\WCJ\\service\\FirstService.exe");
   }
   printf("start？\n");
   if(getch()=='y') 
   {
   	system("sc start FirstService ");
   }return 0;
}