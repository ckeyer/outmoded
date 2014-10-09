# -*- coding: utf-8 -*-

class Book(object):
    def __init__(self,a,b):
        self.a = a
        self.b = b
    def __setattr__(self, a, b):
        if a == 'value':
            object.__setattr__(self, a, b - 100)
        else:
            object.__setattr__(self, a, b)
    def __getattr__(self, a):
        try:
            return object.__getattribute__(a)
        except:
            return a + ' is not found!'
    def __str__(self):
        return self.a + ' cost : ' + str(self.b)

c = Book('Python',100)
print c.a
print c.b
print c
print c.Type