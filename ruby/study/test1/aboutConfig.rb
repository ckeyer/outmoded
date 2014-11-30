#!/usr/local/bin/ruby

require "parseconfig"

config_path = './test.conf'
config=ParseConfig.new(config_path)

config.add("d","sdfsdf")
config.add_to_group("groupC","valuec","hero")
fh = File.new(config_path, "w")

config.write(fh)
puts config['a'].to_i * 2
puts config['groupB']["b"]