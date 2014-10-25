#ifndef CJTEST2_H
#define CJTEST2_H

#include <QGLWidget>
#include <GL/glu.h>
#include <math.h>

class CJTest2 : public QGLWidget
{
public:
    CJTest2();
    ~CJTest2();
protected:
    void initializeGL();
    void paintGL();
    void resizeGL(int width, int height);
    GLdouble Points[5][3];
    GLdouble Points2[5][3];
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

#endif // CJTEST2_H
