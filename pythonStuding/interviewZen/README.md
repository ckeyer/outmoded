## interview ZEN 做题笔记

> http://www.interviewzen.com/apply/5pBh4T#

program1.py
-----------

你了解python的装饰器吗？

实现一个装饰器d2使下面的代码打印相应的结果： 

> @d2('a', 'b') 

> def test(arg1, arg2):

> > print 'test', arg1, arg2 

> test('c', 'd') 

> 

> [output] 

> before test a b 

> test c d 

> [/output] 

program2.py
-----------

Give me a function that takes a list of numbers and returns only the even ones, divided by two. 
(please use list comprehension)

program3.py
-----------

一个数组，里面都是整数，请编写一个程序，使用快速排序排序，并打印排序后的结果，请给出测试集和输出结果。

program4.py
-----------

完成下面的类C，使得所有断言都正确。 

> class C(object):

>     def __init__(self, a, b):

>         self.a = a

>         self.b = b 未完成... 

> 

> a = C(1, 'a') 

> b = C(1, 'a') 

> c = C(1, 'b')

> l = [a, b, c] 

> 

> r = {} 

> 

> for i in l:

>     if i not in r:

>         r[i] = 1

>     else:

>         r[i] += 1 

> 

> assert r[a] == 2 

> assert r[b] == 2 

> assert r[c] == 1 

program5.py
-----------

用python写一个小工具，实现tee命令的功能

program6.py
-----------

编写一个socket程序，守候在900端口，对所有收到的数据原样返回。

program7
-----------

在亚马逊/京东/等等网站上,用户可以收藏图书以备购买,并打上标签,如收藏《红楼梦》时,
可以打上“古典文学”、“曹雪 芹”、“小说”、“名著” 等标签。请设计关系型数据库的表结
构,存储收藏和标签信息,并提供实现以下 需求的查询方式(可以使用SQL和编程语言结合查
询): 

a) 列出一个用户的所有收藏

b) 列出一个用户的所有标签 

c) 列出一个用户的某个标签下的所有收藏 

d) 列出一本书下最热门的标签

program8
--------

1) Linux下最大打开文件数如何调整？

2)某系统管理员需每天做一定的重复工作，请按照下列要求，编制一个解决 方案 ：

（1）在下午4 :50 删除/abc 目录下的全部子目录和全部文件；

（2）从早8:00～下午6:00 每小时读取/xyz 目录下x1 文件中每行第一个域的全部数据
加入到/backup 目录下的bak01.txt 文件内；

（3）每逢星期一下午5:50 将/data 目录下的所有目录和文件归档并压缩为文件：
backup.tar.gz；

（4）在下午5:55 将IDE 接口的CD-ROM 卸载（假设：CD-ROM 的设备名为hdc）；

（5）在早晨8:00 前开机后启动。

program9
--------

RLE压缩 RLE(Run Length Encoding),即行程压缩算法,是一个针对无损压缩的非常简单
的算法。它用重复 字节和重复的次数来简单描述、代替连续出现的重复字节。尽管简单
并且对于通常的压缩非常低效,但 是由于非常适合有大量重复色块的图形,而且解压缩效
率很高,因此应用较为广泛。 RLE 可以使用很 多不同的方法,最简单的做法是:对于不重
复内容,不做转换,对于重复内容,用“控制字节+重复次 数+重复字节”三个字节表达。 请
写出这种简单RLE压缩实现的代码。 当然,不能使用任何有直接帮助的第三方库。请给出
测试数据和输出结果。

program10
---------

Python中__getattr__() 和 __getattribute__有什么区别？请你谈谈对GIL的理解

program11
---------

用python写一个程序，找出数组中差值为K的数共有几对

示例：

差值k=4 and 数组是[7, 6, 23,19,10,11, 9, 3, 15]

这样的结果是(7,11) (7,3) (6,10) (19,23) (15,19) (15,11) 共6对



从标准输入读入两行数据

> 5 2

> 1 5 3 4 2

第一行代表N和K, N是数组是一共有多少数字，K是所要求的差值

第二是数组，空白分格

输出到标准输出


> Sample Input #00:

> 5 2

> 1 5 3 4 2

> Sample Output #00:

> 3

> Sample Input #01:

> 10 1

> 363374326 364147530 61825163 1073065718 1281246024 1399469912 428047635 491595254 879792181 1069262793 

> Sample Output #01:

> 0


program12
---------

谈谈你对SQL注入的理解？谈谈你对XSS的理解?


