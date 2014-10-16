class MyClass
	@@count ||=0
	def initialize(name)
		@name = name
		@@count+=1
	end
	def getName
		@name
	end
	def getCount
		@@count
	end
end

my_object  = MyClass.new("CKey")
my_object2 = MyClass.new("Hero")

p my_object.getName
p my_object.getCount

p my_object.class
p my_object.class.instance_methods(false)
p my_object.instance_variables