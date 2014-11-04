#ifndef CJTEST5GL_H
#define CJTEST5GL_H

//#include <GL/glu.h>
#include <QGLWidget>
#include <QMessageBox>
#include <QMouseEvent>
#include <QTimer>
#include <math.h>
#include "cjclass.h"

#define pi 3.141592654
#define SOLID 3000
#define WIRE  3001

typedef int SPHERE_MODE;

typedef struct Point3f
{
 GLfloat x;
 GLfloat y;
 GLfloat z;
}point;


class CJTest5GL : public QGLWidget
{
    Q_OBJECT

public:
    CJTest5GL();
    QTimer *timer;
    ~CJTest5GL();
protected:
    void initializeGL();
    void paintGL();
    void resizeGL(int width, int height);

private:
    int speed_x,speed_y,speed_z;
    int now_x,now_y,now_z;
    int getPoint(GLfloat radius,GLfloat a,GLfloat b,point &p);
    void drawSlice(point &p1,point &p2,point &p3,point &p4,SPHERE_MODE mode);
    int drawSphere(GLfloat radius,GLint slices,SPHERE_MODE mode);
    point* getPointMatrix(GLfloat radius,GLint slices);
    void mousePressEvent(QMouseEvent *event);
    void mouseMoveEvent(QMouseEvent *event);

    int xRot;
    int yRot;
    int zRot;

    QPoint lastPos;

private slots:
    void nextTag();
public slots:
    void setXRotation(int angle);
    void setYRotation(int angle);
    void setZRotation(int angle);
    void chageXSpeed(int a);
    void chageYSpeed(int a);
    void chageZSpeed(int a);
};
#endif // CJTEST5GL_H
