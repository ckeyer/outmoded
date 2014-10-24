#ifndef CJTEST1_H
#define CJTEST1_H

#include <QGLWidget>
#include <QtMath>
#include <QtGui/QtGui>
#include <GL/glu.h>
#include <QString>

class CJTest1 : public QGLWidget
{
public:
    CJTest1();
    ~CJTest1();
protected:
    void initializeGL();
    void paintGL();
    void resizeGL(int w, int height);
private :
    GLfloat Point[5][3];
};

#endif // CJTEST1_H
