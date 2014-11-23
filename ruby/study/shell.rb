
def test(n=5)
    p  "Start"
    n.times { |i|
        (i+1).times { |j|
            print "*"
        }
        puts ""
    }
end


test(5)
