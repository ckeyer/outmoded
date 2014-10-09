# -*- coding: utf-8 -*-

import time
import thread

count =0
def myTimer(name,num):
    global count
    while num>0:
        count+=1
        print "Thread:(%s)--(%d) Time:%s\n" %(name,count, time.ctime()) 
        num-=1
        time.sleep(1)
    thread.exit_thread()

def test():
    thread.start_new_thread(myTimer,("T1",5))
    thread.start_new_thread(myTimer,("T2",6))
    thread.start_new_thread(myTimer,("T3",3))

if __name__=="__main__":
    print "Thread:(%d) Time:%s\n" %(23, "Now") 
    print time.ctime()
    test()
    time.sleep(10)