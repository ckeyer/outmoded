#include "manager.h"

Manager::Manager()
{
}
Manager::Manager(char *n ,int a, int w, char s, int m, int g,int t,int h, double p)
    :Employee(n,a,w,s,m,g,t)
{
    this->workHours = h;
    this->profit = p;
}
int Manager::getWorkHours()
{
    return this->workHours;
}
void Manager::setWorkHours(int h)
{
    this->workHours = h;
}
void Manager::setProfit(double p)
{
    this->profit = p;
}
Money Manager::getProfit()
{
    return this->profit;
}
Money Manager::getWage()
{
    return this->wage;
}
Money Manager::getSalary()
{
    return this->salary;
}

void Manager::print()
{
    ;
}
