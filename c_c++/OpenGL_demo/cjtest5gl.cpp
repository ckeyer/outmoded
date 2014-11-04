
#include "cjtest5gl.h"


const GLfloat PI = 3.1415926536f;
CJTest5GL::CJTest5GL()
{
    now_x = -90;
    now_y = 0;
    now_z = 0;
    speed_x = 0;
    speed_y = 0;
    speed_z = 1;
}
CJTest5GL::~CJTest5GL()
{
    makeCurrent();
}
void CJTest5GL::nextTag()
{
    now_x = (now_x+speed_x)%360;
    now_y = (now_y+speed_y)%360;
    now_z = (now_z+speed_z)%360;
    updateGL();
}
void CJTest5GL::chageXSpeed(int a)
{
    this->speed_x = a ;
}

void CJTest5GL::chageYSpeed(int a)
{
    this->speed_y = a;
}
void CJTest5GL::chageZSpeed(int a)
{
    this->speed_z = a;
}
void CJTest5GL::initializeGL()
{
    glClearColor (0.0, 0.0, 0.0, 0.0);
    glClearDepth(1);
    glShadeModel(GL_SMOOTH);
    GLfloat _ambient[]={1.0,1.0,1.0,1.0};
    GLfloat _diffuse[]={1.0,1.0,1.0,1.0};
    GLfloat _specular[]={1.0,1.0,1.0,1.0};
    GLfloat _position[]={200,200,200,0};
    glLightfv(GL_LIGHT0,GL_AMBIENT,_ambient);
    glLightfv(GL_LIGHT0,GL_DIFFUSE,_diffuse);
    glLightfv(GL_LIGHT0,GL_SPECULAR,_specular);
    glLightfv(GL_LIGHT0,GL_POSITION,_position);
    glEnable(GL_TEXTURE_2D);
    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
    glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);


    this->timer = new QTimer(this);
    connect(timer, SIGNAL(timeout()), this, SLOT(nextTag()));
    timer->start(10);
}

void CJTest5GL::paintGL()
{
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    glClear (GL_COLOR_BUFFER_BIT|GL_DEPTH_BUFFER_BIT);
    glTranslated(0,0,-9000);
    glRotated(now_x,1,0,0);
    glRotated(now_y,0,1,0);
    glRotated(now_z,0,0,1);
    glColor3f(1.0,1.0,1.0);
    drawSphere(200,20,WIRE);
    glFlush();
}

void CJTest5GL::resizeGL(int width, int height)
{
    glTranslated(40.0, 0.0, -40.0);
    glViewport (0, 0, (GLsizei) width, (GLsizei) height);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    glFrustum(-2.0, +2.2, -1.3, 1.2, 45.0, 30000.0);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
}
int CJTest5GL::getPoint(GLfloat radius,GLfloat a,GLfloat b,point &p)
{
    p.x=radius*sin(a*pi/180.0)*cos(b*pi/180.0);
    p.y=radius*sin(a*pi/180.0)*sin(b*pi/180.0);
    p.z=radius*cos(a*pi/180.0);
    return 1;
}
void CJTest5GL::drawSlice(point &p1,point &p2,point &p3,point &p4,SPHERE_MODE mode)
{
    switch(mode)
    {
    case SOLID:
        glBegin(GL_QUADS);
        break;
    case WIRE:
        glBegin(GL_LINE_LOOP);
        break;
    }
        glColor3f(1,0,0);
        glVertex3f(p1.x,p1.y,p1.z);
        glVertex3f(p2.x,p2.y,p2.z);
        glVertex3f(p3.x,p3.y,p3.z);
        glVertex3f(p4.x,p4.y,p4.z);
    glEnd();
}
point* CJTest5GL::getPointMatrix(GLfloat radius,GLint slices)
{
    int i,j,w=2*slices,h=slices;
    float a=0.0,b=0.0;
    float hStep=180.0/(h-1);
    float wStep=360.0/w;
    int length=w*h;
    point *matrix;
    matrix=(point *)malloc(length*sizeof(point));
    if(!matrix)return NULL;
    for(a=0.0,i=0;i<h;i++,a+=hStep)
        for(b=0.0,j=0;j<w;j++,b+=wStep)
            getPoint(radius,a,b,matrix[i*w+j]);
    return matrix;
}
int CJTest5GL::drawSphere(GLfloat radius,GLint slices,SPHERE_MODE mode)
{
    int i=0,j=0,w=2*slices,h=slices;
    point *mx;
    mx=getPointMatrix(radius,slices);
    if(!mx)return 0;
    for(;i<h-1;i++)
    {
        for(j=0;j<w-1;j++)
        drawSlice(mx[i*w+j],mx[i*w+j+1],mx[(i+1)*w+j+1],mx[(i+1)*w+j],mode);
        drawSlice(mx[i*w+j],mx[i*w],mx[(i+1)*w],mx[(i+1)*w+j],mode);
    }
    free(mx);
    return 1;
}
void CJTest5GL::mousePressEvent(QMouseEvent *event)
{
    lastPos = event->pos();
}

void CJTest5GL::mouseMoveEvent(QMouseEvent *event)
{
    int dx = event->x() - lastPos.x();
    int dy = event->y() - lastPos.y();

    if (event->buttons() & Qt::LeftButton) {
        setXRotation(xRot + 8 * dy);
        setYRotation(yRot + 8 * dx);
    } else if (event->buttons() & Qt::RightButton) {
        setXRotation(xRot + 8 * dy);
        setZRotation(zRot + 8 * dx);
    }
    lastPos = event->pos();
}

void CJTest5GL::setXRotation(int angle)
{
//    normalizeAngle(&angle);
//    if (angle != xRot) {
//        xRot = angle;
//        emit xRotationChanged(angle);
//        updateGL();
//    }
    now_x += angle/10;
}

void CJTest5GL::setYRotation(int angle)
{
//    normalizeAngle(&angle);
//    if (angle != yRot) {
//        yRot = angle;
//        emit yRotationChanged(angle);
//        updateGL();
//    }
    now_y += angle/10;
}

void CJTest5GL::setZRotation(int angle)
{
//    normalizeAngle(&angle);
//    if (angle != zRot) {
//        zRot = angle;
//        emit zRotationChanged(angle);
//        updateGL();
//    }

    now_z += angle/10;
}
