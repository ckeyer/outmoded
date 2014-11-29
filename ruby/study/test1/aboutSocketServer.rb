require "socket"

def test
    # port = 2222 #if ARGV.size > 0 then ARGV.shift else 4444 end
    # print port, "\n"

    s = TCPSocket.open("127.0.0.1", 2222)
    # s = TCPSocket.open("localhost", port)

    while gets
        s.write($_)
        print(s.gets)
    end
    s.close
end

def test2
    server = TCPServer.new 2000 # Server bound to port 2000

    loop do
        client = server.accept    # Wait for a client to connect
        client.puts "Hello !"
        client.puts "Time is #{Time.now}"
        puts client.gets
        client.close
    end    
end

test2