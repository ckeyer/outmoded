# this is my first Ruby program


# require 'io/console'
# rows, columns = $stdin.winsize
# puts "Your screen is #{columns} wide and #{rows} tall"
# class Creature
#   def initialize(name)
#     @name = name
#   end
  
#   def fight
#     return "Punch to the chops!"
#   end
# end

# Add your code below!
# class Dragon < Creature
#     def fight
#         puts "Instead of breathing fire..."
#         super
#     end
# end


def mask(ip1, ip2)
    num = ->(ip) {
        n=ip.split(".")
        puts ip
        n[0].to_i()*0x1000000+n[1].to_i()*0x10000+n[2].to_i()*0x100+n[3].to_i() 
    }
    m=(/(1+)$/.match((num.call(ip1)^num.call(ip2)).to_s(2))[1])
    nip = m.to_i(2)^0xFFFFFFFF
    (nip/0x1000000%0x100).to_s + '.' + (nip/0x10000%0x100).to_s + '.' + (nip/0x100%0x100).to_s + '.' + (nip%0x100).to_s + '/' + m.size.to_s
end
def test(ip1,ip2,ip3)
    num = ->(ip){
      puts ip*3
    }

    num.call(ip1)
    num.call(ip2)
    num.call(ip3)
end
# puts mask("41.58.0.0", "41.58.255.255")

puts test(12,23,34)