#!/usr/local/bin/ruby
require 'redis'
port = 6379
host = "localhost"
begin
    redis = Redis.new(:host => host, :port => port)
    puts redis["ha"]
    puts redis.set("hello","world")
    puts redis.get "hello"
rescue Exception => e
    puts "Error message: #{e.error}"
    puts "Error Over"
ensure
    redis.quit if redis
end


# require 'rubygems'
# require 'redis'
# r = Redis.new
# r.delete('first_key') #clear it out, if it happens to be set
# puts 'Set the key {first_key} to {hello world}'
# r['first_key'] = 'hello world'
# puts 'The value of {first_key} is:'
# puts r['ha']