$text = "Hero"	# 

class Person
	Pi=3.1415
	@@count=0
	def initialize(name, gender, age)
		@name = name
		@gender = gender
		@age = age
		@@count+=1
	end
	def name
		@name
	end
	def pCount
		p "Count :#{@@count}"
	end
end
people = Person.new('Tom', 'male', 15)
puts people.name
people.pCount
p Person::Pi

class  << people
	def gender
		@gender
	end
	def age
		@age
	end
end

def people.pCount
	p "Person Count "
end

puts people.gender
puts people.age
people.pCount

class  << people
	remove_method(:pCount)
end
people.pCount

class  << people
	undef_method(:pCount)
end
people.pCount
