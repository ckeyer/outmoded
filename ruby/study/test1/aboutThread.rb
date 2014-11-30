#!/usr/local/bin/ruby

def func1
   2.times do
      puts "func1 at: #{Time.now}"
      sleep(2)
   end
end

def func2
   2.times do
      puts "func2 at: #{Time.now}"
      sleep(1)
   end
end

puts "Started At #{Time.now}"
t1=Thread.new{func1()}
t2=Thread.new{func2()}
t1.join
t2.join
puts "End at #{Time.now}"