#ifndef CJTEST2_H
#define CJTEST2_H

#include <QGLWidget>

class CJTest2 : public QGLWidget
{
public:
    CJTest2();
    ~CJTest2();
protected:
    void initializeGL();
    void paintGL();
    void resizeGL(int width, int height);
};

#endif // CJTEST2_H
