require "socket"

def testUDPServer
    port = 2222
    s = UDPSocket.new
    s.bind(nil, port)
    loop do
        text, sender = s.recvfrom(254)
        if text != "0" 
            remote_host = sender[3]
            client_port = sender[1]
            puts "#{remote_host}:#{client_port} sent #{text}"
            s.send("#{text} responsed,from server", 0, remote_host, client_port)
        end
    end      
end

def testTCPServer
    server = TCPServer.new 2000 # Server bound to port 2000

    loop do
        client = server.accept    # Wait for a client to connect
        client.puts "Hello !"
        client.puts "Time is #{Time.now}"
        puts client.gets
        client.close
    end    
end

testUDPServer