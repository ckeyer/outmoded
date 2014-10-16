#ifndef TEST3_H
#define TEST3_H

#include <iostream>
using namespace std;

class CPoint
{
public :
    CPoint(double x,double y)
    {
        this->x =x;
        this->y = y;
    }
    double x,y;
    friend CPoint operator + (CPoint one,CPoint two);
};

CPoint operator +(CPoint one,CPoint two)
{
    CPoint sum(one.x+two.x,one.y+two.y);
    return sum;
}

void test3()
{
    CPoint O(2,3);
    CPoint t= O+CPoint(4,2);
    cout<<t.x<<endl<<t.y<<endl;
}

#endif // TEST3_H
