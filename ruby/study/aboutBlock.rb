def test1
    a=(1..5).to_a
    a.each do |x|
        print x
        print " "
    end 
    puts 

    a.each { |x|
        print x
        print " "
    }
    puts
    5.times do |i|
        print "hh"
        print ", " if(i != 4)
    end
    puts
    5.times { |i|
        print "hh"
        print ", " if(i != 4)
    }
end

test1