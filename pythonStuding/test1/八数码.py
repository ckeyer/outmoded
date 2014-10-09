#coding=utf-8
import copy
#copyright@shuxiang29.appspot.com你必须保留这条声明

def init(target):#初始化tlist，方便计算曼哈顿距离
    tlist = [0 for a in range(9)]
    for i in range(3):
        for j in range(3):
            tlist[target[i][j]]=[i,j]
    return tlist

def getStep(tlist,current):#获取曼哈顿距离
    step = 0
    for i in range(3):
        for j in range(3):
            if current[i][j]!=0:
                k = tlist[current[i][j]]
                step = step + abs(k[0]-i) + abs(k[1]-j)
    return step

def inTable(item,table):#在不在opened or closed表中
    it = item[2]
    for t in table:
        t2 = t[2]
        if t2==it:
            return True
    return False

def roop(tlist,item,target):
    opened = []
    closed = []
    opened.append(item)
    #print "roop----opened: ",opened,"\n","closed",closed
    while len(opened):#opened表的长度不为0
        current = opened[0]     #第一个元素
        del opened[0]           #从opened中删除
        closed.append(current)  #移动到closed
        if current[2] == target:#已经找到目标，直接返回，目标已经插入到closed
            return closed
        #以0为点移动##############
        #up   0上移
        #cur1 = current#it means cur1 is current's another name
        cur1 = copy.deepcopy(current)

        for i in range(3):
            for j in range(3):
                if cur1[2][i][j]==0 and i!=0:#不是最顶行，上移，交换位置
                    temp = cur1[2][i-1][j]
                    cur1[2][i-1][j] = cur1[2][i][j]
                    cur1[2][i][j] = temp
                    break
        if cur1 != current:                                 #父是closed最后一个元素的位置
            son1 = [current[0]+1,getStep(tlist,cur1[2]),cur1[2],len(closed)-1]
            if not inTable(son1,closed):
                if not inTable(son1,opened):
                    #insert into opened,方法是按step值小的在前排序插入
                    if len(opened)==0:#如果表长度为0，直接插入表中
                        opened.append(son1)
                    else:
                        for i in range(len(opened)):
                            if opened[i][1] > son1[1]:
                                opened.insert(i,son1)
                                break
                            elif i == len(opened)-1:#如果表中的元素step值都比son1［1］小，插入到表最后
                                opened.append(son1)
                                break
                else:#已经在opened中
                    for i in range(len(opened)-1):#选择layer值小的保留到opened中
                        if opened[i][2]==son1[2]:
                            if opened[i][0] > son1[0]:
                                opened[i] = son1
                                break
        #down    0下移
        cur2 = copy.deepcopy(current)
        for i in range(3):
            for j in range(3):
                if cur2[2][i][j]==0 and i!=2:#不是最底行，下移，交换位置
                    temp = cur2[2][i+1][j]
                    cur2[2][i+1][j] = cur2[2][i][j]
                    cur2[2][i][j] = temp
                    break
        if cur2 != current:                                 #父是closed最后一个元素的位置
            son2 = [current[0]+1,getStep(tlist,cur2[2]),cur2[2],len(closed)-1]
            if not inTable(son2,closed):
                if not inTable(son2,opened):
                    #insert into opened,方法是按step值小的在前排序插入
                    if len(opened)==0:
                        opened.append(son2)
                    else:
                        for i in range(len(opened)):
                            if opened[i][1] > son2[1]:
                                opened.insert(i,son2)
                                break
                            elif i == len(opened)-1:
                                opened.append(son2)
                                break
                else:#已经在opened中
                    for i in range(len(opened)-1):#选择layer值小的保留到opened中
                        if opened[i][2]==son2[2]:
                            if opened[i][0] > son2[0]:
                                opened[i] = son2
                                break
        #left    0左移
        cur3 =  copy.deepcopy(current)
        for i in range(3):
            for j in range(3):
                if cur3[2][i][j]==0 and j!=0:#不是最左行，左移，交换位置
                    temp = cur3[2][i][j-1]
                    cur3[2][i][j-1] = cur3[2][i][j]
                    cur3[2][i][j] = temp
                    break
        if cur3 != current:                                 #父是closed最后一个元素的位置
            son3 = [current[0]+1,getStep(tlist,cur3[2]),cur3[2],len(closed)-1]
            if not inTable(son3,closed):
                if not inTable(son3,opened):
                    #insert into opened,方法是按step值小的在前排序插入
                    if len(opened)==0:
                        opened.append(son3)
                    else:
                        for i in range(len(opened)):
                            if opened[i][1] > son3[1]:
                                opened.insert(i,son3)
                                break
                            elif i == len(opened)-1:
                                opened.append(son3)
                                break
                else:#已经在opened中
                    for i in range(len(opened)-1):#选择layer值小的保留到opened中
                        if opened[i][2]==son3[2]:
                            if opened[i][0] > son3[0]:
                                opened[i] = son3
                                break
        #right   0右移
        cur4 =  copy.deepcopy(current)
        for i in range(3):
            for j in range(3):
                if cur4[2][i][j]==0 and j!=2:#不是最右行，右移，交换位置
                    temp = cur4[2][i][j+1]
                    cur4[2][i][j+1] = cur4[2][i][j]
                    cur4[2][i][j] = temp
                    break
        if cur4 != current:                                 #父是closed最后一个元素的位置
            son4 = [current[0]+1,getStep(tlist,cur4[2]),cur4[2],len(closed)-1]
            if not inTable(son4,closed):
                if not inTable(son4,opened):
                    #insert into opened,方法是按step值小的在前排序插入
                    if len(opened)==0:
                        opened.append(son4)
                    else:
                        for i in range(len(opened)):
                            if opened[i][1] > son4[1]:
                                opened.insert(i,son4)
                                break
                            elif i == len(opened)-1:
                                opened.append(son4)
                                break
                else:#已经在opened中
                    for i in range(len(opened)-1):#选择layer值小的保留到opened中
                        if opened[i][2]==son4[2]:
                            if opened[i][0] > son4[0]:
                                opened[i] = son4
                                break
        #end###############
    
if __name__=="__main__":
    target = [[1,2,3],[8,0,4],[7,6,5]]
    start = [[2,8,3],[1,6,4],[7,0,5]]#[ [0 for a in range(3)] for b in range(3)]
    tlist = init(target)
    #item = [layer:int,step:int,self:[3:3],father:int]
    item = [0,getStep(tlist,start),start,-1]#-1 not father

    closed = roop(tlist,item,target)

    for c in closed:
        print "layer: ",c[0],"step: ",c[1],"father: ",c[3]
        for i in c[2]:
            print i
        print "\n"

    a = raw_input("waiting EnterKey to end...")
    