#ifndef CJCLASS_H
#define CJCLASS_H

#include <GL/glu.h>
#include <QMessageBox>
#include <QString>
#include <QWidget>

class CJClass
{
public:
    CJClass();
    void static showMsg(QString msg);
    void static showMsg(QString msg,QString title);
};

class CJPoint
{
public:
    GLfloat X,Y;
    CJPoint(double x,double y)
    {
        this->X = x;
        this->Y = y;
    }
};

#endif // CJCLASS_H
