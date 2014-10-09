# -*- coding: utf-8 -*-

# 八皇后问题
# cjstudio

import copy
count = 0
lists = [[0 for x in range(8)] for y in range(8)]

def printList(lit):
    print '****************'
    for i in range(len(lit)):
        print lit[i]
        pass
    print '================'
    
def test(lit,h,l):
    for i in range(0,8):
        if lit[h][i]!=0 or lit[i][l]!=0:
            return False
            pass
        if h+i<8 and l+i<8:
            if lit[h+i][l+i]!=0:
                return False
                pass
            pass
        if h-i>=0 and l+i<8:
            if lit[h-i][l+i]!=0:
                return False
                pass
            pass
        if h-i>=0 and l-i>=0:
            if lit[h-i][l-i]!=0:
                return False
                pass
            pass
        if h+i<8 and l-i>=0:
            if lit[h+i][l-i]!=0:
                return False
                pass
            pass
        pass
    return True
    pass

def doRound(lit,h):
    global count
    if h == 8:
        count+=1
        printList(lit)
        return True
        pass
    for i in range(0,8):
        if test(lit,h,i):
            tmplit=copy.deepcopy(lit)
            tmplit[h][i] = 1
#            printList( lit)
            doRound(tmplit,h+1)
        else:
            continue
        pass
    pass

if __name__=="__main__":
    doRound(lists,0)
    print 'Over',count



