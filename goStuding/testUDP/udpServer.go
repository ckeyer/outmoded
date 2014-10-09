package main

import (
	"fmt"
	"net"
)

func main() {
	// 创建监听
	socket, err := net.ListenUDP("udp4", &net.UDPAddr{
		IP:   net.IPv4(127, 0, 0, 1),
		Port: 2222,
	})
	if err != nil {
		fmt.Println("监听失败!", err)
		return
	} else {
		fmt.Println("监听成功!", err)
	}
	defer socket.Close()

	for {
		// 读取数据
		data := make([]byte, 2048)
		read, remoteAddr, err := socket.ReadFromUDP(data)
		if err != nil {
			fmt.Println("读取数据失败!", err)
			continue
		}
		fmt.Println(read, remoteAddr)
		fmt.Printf("%s\n", data)

		// 发送数据
		senddata := []byte("<?xml version=\"1.0\" encoding=\"utf-8\"?><cjstudio type=\"CS_REPLY\" seq=\"0\"><From><IPAddress>127.0.0.1</IPAddress><Port>3333</Port><UserID>1001</UserID><Name>cjstudio</Name></From><To><IPAddress>127.0.0.1</IPAddress><Port>2222</Port><UserID>10000</UserID><Name>server</Name></To><Data><Text>hello serverPC</Text></Data><Hash>DBA1C38D01372E18CE34C24695215270</Hash></cjstudio>")
		_, err = socket.WriteToUDP(senddata, remoteAddr)
		if err != nil {
			return
			fmt.Println("发送数据失败!", err)
		}
	}
}
