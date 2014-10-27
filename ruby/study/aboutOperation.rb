# Operation &  Iterator

def test1
	a=(1..5).to_a
	_,x,*y,z=a
	puts "x=#{x},y=#{y},z=#{z}"
end

def test2
	0.upto(9) { |x| print x , " " }
	puts

	0.step(10,2) { |x| print x , " " }
	puts

	["apple", "ora33nge", "ban12ana", "watermelon"].grep(/\d{2}/) do |fruit|
		print  fruit , " "
	end
	puts 

	for fruit in ["apple", "orange", "banana", "watermelon"]
		print fruit, " "
	end
	puts

	for i in 1..10
		print i, " "
	end
	puts 
end

def test3
	count = 0
	for i in 1..3
		print "hello #{i}\n"
			break if count == 1
			if i > 1
				count += 1
			redo	# i=2
		end
	end
end

def test4
	n = 0
	begin
		puts 'Trying to do something'
		raise 'oops'
	rescue => ex
		puts ex
		n += 1
		retry if n < 3
	end
	puts "Ok, I give up"
end

def test5
	a,b = 4,5
	puts a<=>b,b<=>a
	a = 5
	puts a<=>b,b===a
end

def test6(arg1,arg2,arg3)
	puts arg3+arg2+arg1
end

test6(*(1..3).to_a)
test6(1,2,3)