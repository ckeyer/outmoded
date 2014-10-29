
#include "cjtest2.h"
#include <gl/GLU.h>

CJTest2::CJTest2()
{
    const GLfloat PI = 3.1415926536f;
    short angle = 18;
    for(short i=0;i<5;++i)
    {
        Points[i][0] = cos(angle * PI/180);
        Points[i][1] = sin(angle * PI/180);
        Points[i][2] = 0.0;

        GLdouble x,y,z,wx,wy,wz;
        x = cos(angle * PI/180);
        y = sin(angle * PI/180);
        z = 0.0;

        angle += 72;

        GLdouble mProj[16];
        GLdouble mView[16];
        GLint mPort[4];
//        得到视图，投影，视口的矩阵
        glGetDoublev(GL_PROJECTION_MATRIX,mProj);
        glGetDoublev(GL_MODELVIEW_MATRIX,mView);
        glGetIntegerv(GL_VIEWPORT,mPort);
//        模拟投影，视图，模型变换

        gluProject(x,y,z,mView,mProj,mPort,&wx,&wy,&wz);

        CJClass::showMsg(QString::number(x)+"#"+QString::number(wx)+"\n"
                         +QString::number(y)+"#"+QString::number(wy)+"\n"
                         +QString::number(z)+"#"+QString::number(wz));

        Points2[i][0] = wx;
        Points2[i][1] = wy;
        Points2[i][2] = wz;
    }
}

CJTest2::~CJTest2()
{
    makeCurrent();
}
void CJTest2::initializeGL()
{
    glShadeModel(GL_SMOOTH);

    glClearColor(0.0,0.0,0.0,0.0);
    glClearDepth(1.0);

    glEnable(GL_DEPTH_TEST);

    glDepthFunc(GL_LEQUAL);
    glHint(GL_PERSPECTIVE_CORRECTION_HINT,GL_NICEST);

    glEnableClientState(GL_VERTEX_ARRAY);

    glVertexPointer(3,GL_FLOAT,0,Points2);
}

void CJTest2::paintGL()
{
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    glLoadIdentity();
    glTranslatef(-1.5,0.0,-6.0);
    const int countPoint=8;
    CJPoint *p[countPoint];
    GLdouble tmp = sqrt(2.0) /2 ;
    p[0]=new CJPoint(-1.0,0.0);
    p[1]=new CJPoint(-tmp,tmp);
    p[2]=new CJPoint(0.0,1.0);
    p[3]=new CJPoint(tmp,tmp);
    p[4]=new CJPoint(1.0,0.0);
    p[5]=new CJPoint(tmp,-tmp);
    p[6]=new CJPoint(0.0,-1.0);
    p[7]=new CJPoint(-tmp,-tmp);

    glBegin(GL_LINE_LOOP);
        for(int i=0;i<countPoint-1;i++)
        {
            for(int j=i+1;j<countPoint;j++)
            {
                glVertex3f(p[i]->X,p[i]->Y,0.0);
                glVertex3f(p[j]->X,p[j]->Y,0.0);
            }
        }
    glEnd();

//    glPushMatrix();
//    glTranslated(dx, dy, dz);
//    glRotated(angle, 0.0, 0.0, 1.0);
//    glCallList(gear);
//    glPopMatrix();

//    glBegin(GL_TRIANGLES);
//        glColor3f(1.0f,0.0f,0.0f);
//        glColor3f(0.0f,1.0f,0.0f);
//        glVertex3f(0.0,1.0,0.0);
//        glColor3f(0.0f,0.0f,1.0f);
//        glVertex3f(1.0,1.0,0.0);
//        glColor3f(0.0f,1.0f,0.0f);
//        glVertex3f(1.0,0.0,0.0);
//    glEnd();

    //glTranslatef(3.0,0.0,0.0);

//    glVertexPointer(3,GL_FLOAT,0,Points);

    glTranslatef(3.0,0.0,0.0);

    glBegin(GL_LINE_LOOP);
        glArrayElement(1);
        glArrayElement(4);
        glArrayElement(2);
        glArrayElement(0);
        glArrayElement(3);
    glEnd();
}

void CJTest2::resizeGL(int width, int height)
{
    int side = qMin(width, height);
    glViewport(0,0, width, height);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    glFrustum(-2.5, +2.5, -1.2, 1.3, 5.0, 6.0);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    glTranslated(40.0, 0.0, -40.0);
}
