#!/usr/local/bin/ruby

class MyException < RuntimeError

end

begin
    raise  MyException , "MyException  Testing..."
rescue MyException => e
    puts e.to_s
    puts e.backtrace.join("\n")
ensure
    puts "Test Over..."
end