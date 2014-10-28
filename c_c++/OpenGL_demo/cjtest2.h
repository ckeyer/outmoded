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
    GLfloat Points[5][3];
    GLfloat Points2[5][3];
};

#endif // CJTEST2_H
