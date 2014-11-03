# -*- coding: utf-8 -*-

#你了解python的装饰器吗？
#
#实现一个装饰器d2使下面的代码打印相应的结果： 
#
#@d2('a', 'b') 
#def test(arg1, arg2):         
#    print 'test', arg1, arg2 
#
#test('c', 'd') 
#
#[output] 
#before test a b 
#test c d 
#[/output] 

def d2(a,b):
	def _d2(func):
		def __d2(arg1,arg2):
			print 'before test', a, b
			func(arg1, arg2)
		return __d2
	return _d2
 
 
 

@d2('a', 'b') 
def test(arg1, arg2):         
    print 'test', arg1, arg2 

test('c', 'd')