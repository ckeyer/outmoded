#!/usr/bin/env ruby -wKU

def test1(a,b)
    begin
        return a/b
    rescue ZeroDivisionError => ex
        puts "Error, divide zero"
    ensure
        return 0
    end
    puts ex,"@@@@@@@"
end

a = test1(1,0)
puts "a = #{a}"