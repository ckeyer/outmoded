#!/usr/bin/env ruby -wKU

require  "./aboutModule1.rb"
include Module1
Module1::print_version
puts Module1::Version

puts Module1::addPi(3)