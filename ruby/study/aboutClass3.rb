class Person
	attr_accessor :name,:age,:sex
	def initialize(name,age,sex)
	  @name = name
	  @age=age
	  @sex =sex
	end
	def sayHi
		p "Hi,I'm #{@name}"
	end
end

class Student < Person
	attr_reader :stu_id
	def initialize(name,age,sex,stu_id)
	  @name = name
	  @age=age
	  @sex =sex
	  @stu_id=stu_id
	end
	def sayHi
		p "Hi, I'm #{@name},I'm a Student"
	end
end

Tom = Student.new("Tom",21,"w","23123")
p Tom.age
Tom.sayHi

p defined? Val
p defined? Tom
p defined? 3.12
p defined? Tom.sayHi
p $*
class << Tom
	undef_method(:sayHi)
end	
#Tom.sayHi