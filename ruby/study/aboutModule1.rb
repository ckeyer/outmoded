#!/usr/bin/env ruby -wKU

module Module1	
    include Math
    Version="v_1.0.1"
    def print_version
        puts "v1.0.1"
    end
    def addPi(ver)
        return Math::PI + var
    end
    end
include  Module1
p Module1::addPi(12)