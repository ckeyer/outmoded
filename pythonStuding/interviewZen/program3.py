# -*- coding: utf-8 -*-

# 一个数组，里面都是整数，请编写一个程序，使用快速排序排序
#，并打印排序后的结果，请给出测试集和输出结果。

def sortQuict(listNum,leftIndex=0,rightIndex=0):
    i=leftIndex
    if rightIndex==0:
        rightIndex=len(listNum)-1
    j=rightIndex
    flag=1
    if rightIndex-leftIndex<=0:
        return
    else:
        key=listNum[i]
        while(i<j):
            if flag>0:
                if listNum[j]<key:
                    listNum[i],listNum[j] = listNum[j],listNum[i]
                    flag*=-1
                else:
                    j-=1
            else:
                if listNum[i]>key:
                    listNum[i],listNum[j] = listNum[j],listNum[i]
                    flag*=-1
                else:
                    i+=1
        if rightIndex-leftIndex==i+1:
            sortQuict(listNum,leftIndex,i-1)
        elif i==leftIndex :
            sortQuict(listNum,leftIndex+1,rightIndex)
        else :
            sortQuict(listNum,leftIndex,i-1)
            sortQuict(listNum,i+1,rightIndex)
            
def test():
    testList=[56, 45,34 ]
    l1=[33,31,25,22,45,17,70,56]
    print 'input',testList
    sortQuict(testList)
    print 'output',testList
    
    print 'input',l1
    sortQuict(l1)
    print 'output',l1
    
if __name__ == "__main__":
    test()