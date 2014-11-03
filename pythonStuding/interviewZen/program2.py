# -*- coding: utf-8 -*-

# Give me a function that takes a list of numbers and
# returns only the even ones, divided by two. (please
# use list comprehension)

def func(listIn):
    return [i for i in listIn if i % 2==0]

if __name__=="__main__":
    testList = [1,2,3,4,5,6,7,8]
    testList2=[1,3,5,2]
    print func(testList)
    print func(testList2)