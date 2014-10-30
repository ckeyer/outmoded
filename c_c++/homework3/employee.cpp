#include "employee.h"

Employee::Employee(char *_name, int _age, int _worktime,
                   char _sex, int _marriage, int _grade, int _tired)
{
    this->name = _name;
    this->age = _age;
    this->worktime = _worktime;
    this->sex = _sex;
    this->marriage = _marriage;
    this->grade = _grade;
    this->tired = _tired;
    this->wage
}

void Employee::setName(char *s);
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
