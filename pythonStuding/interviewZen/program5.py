# -*- coding: utf-8 -*-

# 用python写一个小工具，实现tee命令的功能

import sys

class CJTee(file):
    def write(self, text):
        sys.stdout.write(text)
        file.write(self, text)
    def test(self,text):
        print text
line = sys.stdin.readline()
t = CJTee(sys.argv[2], "a")
t.write(line) # for write