require 'socket'

def testTcpClient
    s = TCPSocket.new 'localhost', 2000

    s.puts "FFFFFF"
    while line = s.gets # Read lines from socket
        puts line         # and print them
    end
    s.close             # close socket when done 
end

def testUdpClient
    port = 1111
    server_port = 2222
    s = UDPSocket.new
    s.bind(nil, port)
     
    5.times do
        s.send("Udp from client", 0, 'localhost', server_port)
        text, sender = s.recvfrom(254)
        remote_host = sender[3]
        puts "#{remote_host}:#{server_port} responsed #{text}"
    end
end

testUdpClient