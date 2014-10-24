def test1
	a=(1..5).to_a
	_,x,*y,z=a
	puts "x=#{x},y=#{y},z=#{z}"
end

test1