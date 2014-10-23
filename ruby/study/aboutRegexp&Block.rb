def test1
	str="This a Ruby File.12-22133 card is 12-her-123 sdfadfxcv"
	reg=/\d{2}-\c{3}-\d{3}/
	reg2=/\d{2}-\d{5}/
	str =~ reg2
	puts $&
	puts $`
	puts  $'
end

def meth1(p1, p2, &block)
#	puts block.inspect
	puts block.call
end
meth1(1, 2) { "This is a block" }

block = Proc.new { puts "a block" }
block.call

block = lambda { puts "a lambda" }
block.call


def test2
	b=(1..5).to_a
	c = b.map { |e|  e*e }
	puts c.inspect

	d=(1..100).inject(0) { |sum, i| sum+i }
	puts "1+2+3+...+100=#{d}"
end
def fibonacii(max)
	f1, f2 = 1, 1
	while f1 <= max
		yield f1
		f1, f2 = f2, f1+f2
	end
end
fibonacii(1000) { |f| print f, " " }