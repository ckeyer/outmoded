# -*- coding: utf-8 -*-

#用python写一个程序，找出数组中差值为K的数共有几对

import sys
import string

def func(listIn,n):
    count =0
    for i in range(len(listIn)):
        for j in listIn[i:]:
            if abs(listIn[i]-j) ==n:
                count +=1
    return count

times=0
count=0
n=0
listIn =[]
while times!=1:
    line = sys.stdin.readline() # 一次只读一行
    if not line: # 如果是空行(^Z)就停止
        continue
    a = line.split() 
    count=int(a[0]) 
    n= int(a[1])
    times+=1
    
while times!=2:
    line = sys.stdin.readline() # 一次只读一行
    if not line: # 如果是空行(^Z)就停止
        continue
    a = line.split()
    for i in a:
		listIn.append(string.atoi(i))
    times+=1

print func(listIn,n)
