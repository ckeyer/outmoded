#ifndef TEST5_H
#define TEST5_H

#include <iostream>
using namespace std;

class Person
{
public :
    char* Job;
    double BasePay ,CountPay;
    virtual void pPay()=0;
};

class FullTime :public Person
{
public :
    double SaleCount,Percent;
    FullTime(char* job,double basePay,double saleCount,double percent)
    {
        this->Job = job;
        this->BasePay= basePay;
        this->SaleCount = saleCount;
        this->Percent = percent;
        this->CountPay=this->BasePay+saleCount*percent;
    }
    void pPay()
    {
        cout<<"***Job: "<<this->Job<<"***"<<endl
           <<"Base pay: "<<this->BasePay<<endl
          <<"Count pay :"<<this->CountPay<<endl;
    }
};

class CEO:public FullTime
{
public:
    CEO():FullTime("CEO",10000,0,0)
    {}
};
class SaleCEO:public FullTime
{
public:
    SaleCEO(double saleCount):FullTime("Sale CEO",5000,saleCount,0.05)
    {}
};
class Saler:public FullTime
{
public:
    Saler(double saleCount):FullTime("Saler",0,saleCount,0.15)
    {}
};

class PartTime:public Person
{
public:
    double Hours;
    PartTime(double hours)
    {
        this->Job = "Part-time Job";
        this->Hours = hours;
        this->CountPay= hours*120;
    }
    void pPay()
    {
        cout<<"*****Job: "<<this->Job<<"*****"<<endl
           <<"Work time: "<<this->Hours<<endl
          <<"Count pay :"<<this->CountPay<<endl;
    }
};
void test5()
{
    double saleCount = 100000,hours=32;
    CEO ceo;
    SaleCEO sCeo(saleCount);
    Saler saler(saleCount);
    PartTime part(hours);

    ceo.pPay();
    sCeo.pPay();
    saler.pPay();
    part.pPay();

}

#endif // TEST5_H
