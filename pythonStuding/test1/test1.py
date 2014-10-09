# -*- coding: utf-8 -*-

class C(object):         
    def __init__(self, kint, vstr):
        self.kint = kint
        self.vstr = vstr
    def __str__(self):
        return self.a

a = C(1, 'a') 
b = C(1, 'a') 
c = C(1, 'b')

clist = [a, b, c]

dirct = {}

for i in clist:         
    if i not in dirct:
        dirct[i] = 1
    else:                 
        dirct[i] += 1 

print 'a',dirct[a]
print 'b',dirct[b]
print 'c',dirct[c]
assert dirct[a] == 2 
assert dirct[b] == 2 
assert dirct[c] == 1 