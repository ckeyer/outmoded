# -*- coding: utf-8 -*-





class C(object):
    """docstring for C"""
    def __init__(self, a,b):
        self.a =a
        self.b = b
    def __hash__(self):
        return id(b)
    def __eq__(self,a):
        return self.b == a.b
    def __str__(self):
        return str(id(a))+str(id(b))
a= C(1,'a')
b= C(1,'a')
c= C(1,'b')
l = [a,b,c]
print a
print b
print c