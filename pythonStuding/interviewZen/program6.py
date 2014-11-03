# -*- coding: utf-8 -*-

#编写一个socket程序，守候在900端口，对所有收到的数据原样返回。

import socket
address=('127.0.0.1',900)
s=socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
s.bind(address)
while True:
    data,addr = s.recvfrom(1024)
    if not data:
        break
    s.sendto(data,addr)
    print 'received:',data,'from',addr
s.close()