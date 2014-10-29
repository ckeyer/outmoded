#ifndef CJCLASS_H
#define CJCLASS_H

#include <QMessageBox>
#include <QString>
//#include <GL/glu.h>

class CJClass
{
public:
    CJClass();
    void static showMsg(QString msg);
    void static showMsg(double num);
    void static showMsg(QString msg,QString title);
};

class CJPoint
{
public:

    double X,Y;
    CJPoint(double x,double y)
    {
        this->X = x;
        this->Y = y;
    }
};

#endif // CJCLASS_H
