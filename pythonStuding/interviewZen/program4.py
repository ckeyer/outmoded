# -*- coding: utf-8 -*-
#
#完成下面的类C，使得所有断言都正确。 
#
#class C(object):         
#    def __init__(self, a, b):                 
#        self.a = a                 
#        self.b = b 未完成... 
#
#a = C(1, 'a') 
#b = C(1, 'a') 
#c = C(1, 'b')
#
#l = [a, b, c] 
#
#r = {} 
#
#for i in l:         
#    if i not in r:                 
#        r[i] = 1         
#    else:                 
#        r[i] += 1 
#
#assert r[a] == 2 
#assert r[b] == 2 
#assert r[c] == 1 

class C(object):         
    def __init__(self, a, b):                 
        self.a = a                 
        self.b = b 
        
    def __hash__(self):
        return self.a
        
    def __eq__(self,other):
        return self.a==other.a and self.b==other.b
        
a = C(1, 'a') 
b = C(1, 'a') 
c = C(1, 'b')

l = [a, b, c] 

r = {}

for i in l:
    if i not in r:
        r[i] = 1
    else:
        r[i] += 1 

assert r[a] == 2 
assert r[b] == 2 
assert r[c] == 1 
