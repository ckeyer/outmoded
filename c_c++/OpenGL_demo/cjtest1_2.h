#ifndef CJTEST1_2_H
#define CJTEST1_2_H

#include <QGLWidget>
#include <QtMath>
#include <QtGui/QtGui>
#include <QString>
#include <GL/glu.h>

class CJTest1_2 : public QGLWidget
{
public:
    CJTest1_2();
    ~CJTest1_2();
protected:
    void initializeGL();
    void paintGL();
    void resizeGL(int w, int height);

    void mousePressEvent(QMouseEvent *event);
    void mouseMoveEvent(QMouseEvent *event);


    int xRot;
    int yRot;
    int zRot;
    QPoint lastPos;
private :
    GLfloat Point[5][3];
};

#endif // CJTEST1_2_H
