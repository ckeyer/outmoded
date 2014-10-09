# -*- coding: utf-8 -*-

import time
import threading

class CJThread(threading.Thread):
    def __init__(self,name,num,interval):
        threading.Thread.__init__(self)
        self.num = (num)
        self.name = name
        self.interval = interval
        self.thread_stop = False
        
    def run(self):
        try:
            CJThread.count +=1
        except:
            CJThread.count =1
        while self.num >0 and not self.thread_stop: 
            self.num -=1
            print self.name+"--"+time.ctime()+" Count:"+str(CJThread.count)
            time.sleep(self.interval)
        CJThread.count -=1
    
    def stop(self):
        self.thread_stop = True
        CJThread.count -=1

def test():
    t1 = CJThread("Thread1",3,2)
    t2 = CJThread("Thread2",5,1)
    t3 = CJThread("Thread3",3,4)
    t1.start()
    t2.start()
    time.sleep(3)
    t3.start()
#    time.sleep(5)
#    t1.stop()
#    t2.stop()
    
if __name__=="__main__":
    test()