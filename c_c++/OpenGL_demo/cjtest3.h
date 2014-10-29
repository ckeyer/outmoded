#ifndef CJTEST3_H
#define CJTEST3_H

//#include <GL/glu.h>
#include <QGLWidget>
#include <QMessageBox>
#include <QTimer>
#include <math.h>
#include "cjclass.h"

class CJTest3 : public QGLWidget
{
    Q_OBJECT

public:
    CJTest3();
    QTimer *timer;
    ~CJTest3();
protected:
    void initializeGL();
    void paintGL();
    void resizeGL(int width, int height);
    void drawOne();
private:
    GLfloat Points[5][3];
    GLfloat Points2[5][3];
    int spin;
private slots:
    void nextTag();
};
#endif // CJTEST3_H
