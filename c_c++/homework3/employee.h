#ifndef EMPLOYEE_H
#define EMPLOYEE_H

#include "money.h"

class Employee
{
private:
    char *name;
    int age;
    int worktime;   // 工龄
    int marriage;   // 0: 未婚，1: 已婚
    int grade;      // 等级
    char sex;       // f: 女， m: 男
    int tired;      // 0: 离职 1: 在职
protected:
    Money wage;     // 工资
    Money salary;   // 奖金
public:
    Employee(char *_name,int _age,int _worktime, char _sex,int _marriage
             ,int _grade,int _tired);
    void setName(char *s);
    char *getName();
    void setAge(int a);
    int getAge();
    void setWorktime(int w);
    int getWorktime();
    void setSex(char s);
    char getSex();
    void setMarriage(int i);
    int getMarriage();
    void setGrade(int g);
    int getGrade();
    void setTired(int t);
    int getTired();
    void setWage(int w);
    int getWage();
    void setSalary(int s);
    int getSalary();
    void print();
};

#endif // EMPLOYEE_H
