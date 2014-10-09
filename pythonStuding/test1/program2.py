# -*- coding: utf-8 -*-
# 队列和栈的学习

class CJNodeTree(object):
    def __init__(self,data,left=0,right=0):
        self.left = left
        self.data = data
        self.right = right
        self.output = list("")
    def outPut(self):
        if self.right!=0:
            self.output.append( self.right.outPut())
        if self.left!=0:
            self.output.append(self.left.outPut())        
        self.output.append(self.data)
        return self.output

class CJExp(object):
    def __init__(self,strIn):
        self.strIn = strIn        
        self.stack = list("")
        self.output = list("")
        self.cellList = list("")
        lit = list(strIn)
        while(len(lit)>0):
            self.cellList.append(self.__getCell(lit))
    
    def __getCell(self,lit):
        aChar = lit.pop(0)
        if not aChar.isalnum() :
            return aChar
        else:
            num =aChar
            if len(lit)==0:
                return str(num)
            bChar=lit[0]
            while bChar.isalnum() and len(lit)>0:
                num += lit.pop(0)
                if len(lit)==0:
                    break
                bChar=lit[0]
                pass
            return num
            
    def chage(self):
        while(len(self.cellList)>0):
            cell = self.cellList.pop(0)
            if cell.isalnum():
                self.output.append(cell)
            else:
                if cell==")":
                    while(self.stack):
                        symbol=self.stack.pop()
                        if symbol=="(":
                            break;
                        self.output.append(symbol)
                        pass
                else:
                    if cell=="-" or cell=="+":
                        isHigher = False    # 是否存在优先级问题
                        if len(self.stack)==0:
                            continue
                        top = self.stack.pop()
                        while top=="*" or top=="/":
                            self.output.append(top)
                            isHigher = True
                            if len(self.stack)!=0:
                                top = self.stack.pop()
                            else:
                                break
                        if not isHigher:
                            self.stack.append(top)
                    self.stack.append(cell)
        while(len(self.stack)>0):
            self.output.append(self.stack.pop())
            
    def getOutput(self):
        strtmp = ""
        for index in range(len(self.output)):
            strtmp += self.output[index]+" "
        return strtmp
        
    def printOutput(self):
        print self.getOutput()

if __name__ == "__main__":
    print "Start"
    inputStr="9+(13-21)*3+10/2"
    print inputStr
    exp = CJExp(inputStr)
    exp.chage()
    exp.printOutput()
    print "Over"

