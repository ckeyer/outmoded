
#include "cjtest4gl.h"


const GLfloat PI = 3.1415926536f;
CJTest4GL::CJTest4GL()
{
    max_x = 1.4;
    min_x = -2.35;
    max_y = 0.55;
    min_y = -0.45;
    now_x = min_x;
    now_y = min_y;
    step_x = 0.05;
    step_y = 0.02;
    this->countPoints = 5;
    short angle = 0;
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
    double angle = 0.0;
    for(short i=0;i<countPoints;++i)
    {
        this->pPoints[i]=new CJPoint( cos(angle * PI/180),
                          sin(angle * PI/180) );
        angle += 360.0 / countPoints;
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
    if(now_x + step_x > max_x || now_x + step_x < min_x)
    {
        step_x *= -1.0;
    }
    if(now_y + step_y > max_y || now_y + step_y < min_y)
    {
        step_y *= -1.0;
    }
    now_x += step_x;
    now_y +=step_y;
    updateGL();
}
void CJTest4GL::chageCountPoints(int pointCount)
{
    this->countPoints = pointCount;
    double angle = 0.0;
    for(short i=0;i<countPoints;++i)
    {
        this->pPoints[i]=new CJPoint( cos(angle * PI/180),
                          sin(angle * PI/180) );
        angle += 360.0 / countPoints;
    }
}
void CJTest4GL::chageXSpeed(int a)
{
    step_x= step_x>0?a/100.0:a*-1.0/100;
}

void CJTest4GL::chageYSpeed(int a)
{
    step_y= step_y>0?a/100.0:a*-1.0/100;
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

//    glTranslatef(-2.35,-0.45,-6.0);

    glTranslatef(now_x,now_y,-6.0);

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
    glFrustum(-2.8, +2.0, -1.2, 1.3, 5.0, 6.0);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    glTranslated(40.0, 0.0, -40.0);
}
