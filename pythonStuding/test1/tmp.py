# -*- coding: utf-8 -*-

import redis
import urllib2

def testRedis():
    r = redis.StrictRedis(host='localhost',port=6379,db=0)
    print r.get('haa')
    
def testDownload(url):
    response = urllib2.urlopen(url)
    html = response.read()
    return html
    
def func1(lit):
    ll= []
    for i in range(len(lit)):
        if lit[i]%2==0:
            ll.append(lit[i])
    return ll
    


if __name__ == "__main__":
#    print testDownload('http://www.baidu.com/')
#    testRedis()
    a=[1,2,3,4,5,6]
    print func1(a)
    
