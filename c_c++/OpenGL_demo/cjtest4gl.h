#ifndef CJTEST4GL_H
#define CJTEST4GL_H

//#include <GL/glu.h>
#include <QGLWidget>
#include <QMessageBox>
#include <QTimer>
#include <math.h>
#include "cjclass.h"

#define MAXCOUNTPOINTS 36

class CJTest4GL : public QGLWidget
{
    Q_OBJECT

public:
    CJTest4GL();
    CJTest4GL(int Points);
    QTimer *timer;
    ~CJTest4GL();
    int countPoints;
protected:
    void initializeGL();
    void paintGL();
    void resizeGL(int width, int height);
private:
    double max_x,min_x, max_y,min_y,step_x,step_y,now_x,now_y;
    CJPoint *pPoints[MAXCOUNTPOINTS];
    int spin;
private slots:
    void nextTag();
public slots:
    void chageCountPoints(int a);
    void chageXSpeed(int a);
    void chageYSpeed(int a);
};
#endif // CJTEST4GL_H
