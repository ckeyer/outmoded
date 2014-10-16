#ifndef TEST2_H
#define TEST2_H

#include <iostream>
#include <list>
using namespace std;
class Student
{
public :
    Student(char* name,double math,double clang,double assem)
    {
        this->Name = name;
        this->Math = math;
        this->Assem = assem;
        this->CLang = clang;
    }
    char *Name;
    double Math,CLang,Assem;
    int operator < (Student other)
    {
        if (this->getCount()>other.getCount())
            return 1;
        else
            return 0;
    }
    double getCount()
    {
        return this->Math+this->Assem+this->CLang;
    }
    void printStu()
    {
        cout<<this->Name<<"\t"
           <<this->Math<<"\t"
          <<this->CLang<<"\t"
         <<this->Assem<<"\t"
        <<this->getCount()<<"\t"<<endl;
    }
};

typedef list<Student> LISTSTU;
LISTSTU::iterator stuiter;
void test2()
{
    LISTSTU stus ;
    Student a("Hero",1.9,8.2,3);
    stus.push_back(a);
    stus.push_back(Student("Maria",3,2.1,3));
    stus.push_back(Student("CKey",3,7.0,3.6));
    stus.push_back(Student("Mono",3,5.1,3.6));
    stus.push_back(Student("Redia",6.5,5,3.6));
    stus.sort();
    cout<<"Name"<<"\t"
       <<"Math"<<"\t"
      <<"CLang"<<"\t"
     <<"Assem"<<"\t"
    <<"Count"<<"\t"<<endl;
    for (stuiter = stus.begin(); stuiter != stus.end(); ++stuiter)
    {
        stuiter->printStu();
    }
}

#endif // TEST2_H
