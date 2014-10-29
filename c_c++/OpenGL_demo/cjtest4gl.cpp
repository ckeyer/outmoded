
#include "cjtest4gl.h"


const GLfloat PI = 3.1415926536f;
CJTest4GL::CJTest4GL()
{
    this->countPoints = 5;
    short angle = 18;
    for(short i=0;i<countPoints;++i)
    {
        this->pPoints[i]=new CJPoint( cos(angle * PI/180),
                          sin(angle * PI/180) );
        angle += 360 / countPoints;
    }
    spin = 0;
}
CJTest4GL::CJTest4GL(int points)
{
    this->countPoints = points;
    short angle = 18;
    for(short i=0;i<countPoints;++i)
    {
        this->pPoints[i]=new CJPoint( cos(angle * PI/180),
                          sin(angle * PI/180) );
        angle += 360 / countPoints;
    }
    spin = 0;
}
CJTest4GL::~CJTest4GL()
{
    makeCurrent();
}
void CJTest4GL::nextTag()
{
    //CJClass::showMsg(tr("sdfsdf"+spin));
    spin+=1;
    if(spin>360)
    {
        spin-=360;
    }
    updateGL();
}
void CJTest4GL::chageCountPoints(int pointCount)
{
    this->countPoints = pointCount;
    short angle = 18;
    for(short i=0;i<countPoints;++i)
    {
        this->pPoints[i]=new CJPoint( cos(angle * PI/180),
                          sin(angle * PI/180) );
        angle += 360 / countPoints;
    }
}

void CJTest4GL::initializeGL()
{
    glShadeModel(GL_SMOOTH);

    glClearColor(0.0,0.0,0.0,0.0);
    glClearDepth(1.0);

    glEnable(GL_DEPTH_TEST);

    glDepthFunc(GL_LEQUAL);
    glHint(GL_PERSPECTIVE_CORRECTION_HINT,GL_NICEST);

    glEnableClientState(GL_VERTEX_ARRAY);


    this->timer = new QTimer(this);
    connect(timer, SIGNAL(timeout()), this, SLOT(nextTag()));
    timer->start(20);
}

void CJTest4GL::paintGL()
{
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    glLoadIdentity();

    glTranslatef(-1.5,0.0,-6.0);

    glPushMatrix();
    glRotatef(spin,0,0,1.0);
    glColor3f(1.0,1.0,1.0);


    glBegin(GL_LINE_LOOP);
        for(int i=0;i<countPoints-1;i++)
        {
            for(int j=i+1;j<countPoints;j++)
            {
                glVertex3f(pPoints[i]->X,pPoints[i]->Y,0.0);
                glVertex3f(pPoints[j]->X,pPoints[j]->Y,0.0);
            }
        }
    glEnd();
    glPopMatrix();

}

void CJTest4GL::resizeGL(int width, int height)
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
