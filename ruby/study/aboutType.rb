def testHash
	h={"first"=>"Tom","second"=>"Jack","third"=>"Mike"}
	p h["second"]
	h["Forth"]="Hero"
	p h.length
end

def testNum
	num = 128
	6.times do
		puts "#{num.class}: #{num}"
		num *= num
	end
end

def testArray1
	a=["first" "second" "third"]
	b=["first", "second", "third"]
	p a
	p b
	p a.class
	p b.class
	p a.length
	p b.length		
end
def testArray2
	a=Array.new
	p a 
	a[2]="sdf"
	p a
	b=Array.new(10) do |i| 
		i||=0 
		i+=1
	end
	p b
	p b[0...5]
	p b[0..5]
	p b[5..-2]
end
def testNum2
	p 020
	p 0x10
	p 0b10000
	p '%X' % 15
	p '%x' % 15
	p '%d' % 15
	p '%o' % 15
end
def testString
	s= %q/Sdfsd"sdfads"sffsdf/
	p s
	s= %Q[This is a string]
	p s
	s= %q<This is a string>
	p s
	string = <<END_OF_STRING
With publication started in June 1948 and a current circulation of 3 million,
People's Daily is the most influential and authoritative newspaper in China.
According to UNESCO, it takes its place among the world top 10.
END_OF_STRING
	p string
end
def testRange
	a=(1..10).to_a
	p a
	b=("abc".."abd").to_a
	p b

	a.each do |i|
		print i, " " if i==3 .. i==6
	end
	puts
	p ("a".."g") === "c"
end

def testSwitch(scoll )
	
	case scoll
	when 90..100
		print "A"
	when 80...90
		puts "B"
	when 60...80
		puts "C"
	else
		puts "D"
	end
end
def testSymbol
	test = 4
	k=:test
	"test2".to_sym =2
	puts k.class
end

testSymbol