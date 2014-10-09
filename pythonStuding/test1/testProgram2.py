# -*- coding: utf-8 -*-

# -*- coding: utf-8 -*-

import unittest
import program2

class cjClasstest(unittest.TestCase):
    
    ##初始化工作
    def setUp(self):
        pass
    
    #退出清理工作
    def tearDown(self):
        pass
    
    # 测试对象初始化过程
    def testClassInit(self):
        inputStr="9+(13-21)*3+10/2"
        outputList=['9','+','(','13','-','21',')','*','3','+','10','/','2']
        testClass = program2.CJExp(inputStr)
        self.assertEqual(testClass.cellList, outputList, 'test Class init fail')   
        
    # 测试整个运行过程
    def testClassCJExp(self):
        inputStr="9+(13-21)*3+10/2"
        outputStr="9 13 21 - 3 * 10 2 / + "
        testClass = program2.CJExp(inputStr)
        testClass.chage()
        self.assertEqual(testClass.getOutput(), outputStr, 'test Class CJExp fail')
        
        
if __name__ =='__main__':
    unittest.main()