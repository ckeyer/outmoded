# this is my first Ruby program


require 'io/console'
rows, columns = $stdin.winsize
puts "Your screen is #{columns} wide and #{rows} tall"
class Creature
  def initialize(name)
    @name = name
  end
  
  def fight
    return "Punch to the chops!"
  end
end

# Add your code below!
class Dragon < Creature
    def fight
        puts "Instead of breathing fire..."
        super
    end
end
