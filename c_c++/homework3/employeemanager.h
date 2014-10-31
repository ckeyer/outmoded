#ifndef EMPLOYEEMANAGER_H
#define EMPLOYEEMANAGER_H

#include <iostream>
#include <list>
#include "employee.h"


using namespace std;

class EmployeeManager
{
    typedef list<Employee> LIST_EMP;
    LIST_EMP::iterator i_emp;

    enum SITE_IFACE
    {
        MAIN_IFACE=0,
        OVER_IFACE=-1
    };

private:
    LIST_EMP *e;
    int count_manager;
    int count_saler;
    int count_worker;

    SITE_IFACE interWel();
public:
    EmployeeManager();
    ~EmployeeManager();
    void addEmployee(Employee e);
    void operator +(Employee e);
    void deleteEmployee(int index);
    void updateEmployee(int index);
    Money computeWage();
    Money computeSalary();
    void select();
    void save();
    int xitongjiemian(SITE_IFACE site);
    void print();
};

#endif // EMPLOYEEMANAGER_H
