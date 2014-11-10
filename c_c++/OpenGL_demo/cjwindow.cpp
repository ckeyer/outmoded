#include "cjwindow.h"
#include "ui_cjwindow.h"

CJWindow::CJWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::CJWindow)
{
    ui->setupUi(this);
    uiStatus=NOTHING;
    this->init();
}
CJWindow::~CJWindow()
{
    delete ui;
}
void CJWindow::init()
{
//    this->showTest5();
    this->showHome();
}

void CJWindow::clearHome()
{
    switch (uiStatus) {
    case HOME:
        this->glWidgetHome->~GLWidget();
        glWidgetHome=NULL;
        break;
    case TEST1_2:
        this->cjTest1_2->~CJTest1_2();
        cjTest1_2=NULL;
        break;
    case TEST1:
        this->cjTest1->~CJTest1();
        cjTest1=NULL;
        break;
    case TEST2:
        this->cjTest2->~CJTest2();
        cjTest2=NULL;
        break;
    case TEST3:
        this->cjTest3->~CJTest3();
        cjTest3=NULL;
        break;
    case TEST4:
        this->cjTest4->~CJTest4();
        cjTest4=NULL;
        break;
    case TEST5:
        this->cjTest5->~CJTest5();
        cjTest5=NULL;
        break;
    default:
        break;
    }
    uiStatus = NOTHING;
    ui->action_Home->setEnabled(true);
    ui->action_test1->setEnabled(true);
    ui->actionTest1_2->setEnabled(true);
    ui->actionTest_2->setEnabled(true);
    ui->actionTest_3->setEnabled(true);
    ui->actionTest_4->setEnabled(true);
    ui->actionTest_5->setEnabled(true);
}
void CJWindow::showHome()
{
    uiStatus = HOME;
    glWidgetHome = new GLWidget;
    ui->scrollArea_home->setWidget(glWidgetHome);
    ui->scrollArea_home->setWidgetResizable(true);
    ui->scrollArea_home->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    ui->scrollArea_home->setMinimumSize(50, 50);
}
void CJWindow::showTest1()
{
    uiStatus=TEST1;
    this->cjTest1 = new CJTest1;
    ui->scrollArea_home->setWidget(cjTest1);
    ui->scrollArea_home->setWidgetResizable(true);
    ui->scrollArea_home->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    ui->scrollArea_home->setMinimumSize(50, 50);
}
void CJWindow::showTest1_2()
{
    uiStatus=TEST1_2;
    this->cjTest1_2 = new CJTest1_2;
    ui->scrollArea_home->setWidget(cjTest1_2);
    ui->scrollArea_home->setWidgetResizable(true);
    ui->scrollArea_home->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    ui->scrollArea_home->setMinimumSize(50, 50);
}
void CJWindow::showTest2()
{
    uiStatus=TEST2;
    this->cjTest2 = new CJTest2;
    ui->scrollArea_home->setWidget(cjTest2);
    ui->scrollArea_home->setWidgetResizable(true);
    ui->scrollArea_home->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    ui->scrollArea_home->setMinimumSize(50, 50);
}
void CJWindow::showTest3()
{
    uiStatus=TEST3;
    this->cjTest3 = new CJTest3;
    ui->scrollArea_home->setWidget(cjTest3);
    ui->scrollArea_home->setWidgetResizable(true);
    ui->scrollArea_home->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    ui->scrollArea_home->setMinimumSize(50, 50);
}
void CJWindow::showTest4()
{
    uiStatus=TEST4;
    this->cjTest4 = new CJTest4;
    ui->scrollArea_home->setWidget(cjTest4);
    ui->scrollArea_home->setWidgetResizable(true);
    ui->scrollArea_home->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    ui->scrollArea_home->setMinimumSize(50, 50);

//    connect(test4dial,SIGNAL(actionTriggered(int)), cjTest4, SLOT(chageCountPoints(int)));
//    connect(test4dial,SIGNAL(actionTriggered(int)), test4label,SLOT(setNum(int)));
}
void CJWindow::showTest5()
{
    uiStatus=TEST5;
    this->cjTest5 = new CJTest5;
    ui->scrollArea_home->setWidget(cjTest5);
    ui->scrollArea_home->setWidgetResizable(true);
    ui->scrollArea_home->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    ui->scrollArea_home->setMinimumSize(50, 50);

//    connect(test4dial,SIGNAL(actionTriggered(int)), cjTest4, SLOT(chageCountPoints(int)));
//    connect(test4dial,SIGNAL(actionTriggered(int)), test4label,SLOT(setNum(int)));
}

void CJWindow::on_action_Home_triggered()
{
    this->clearHome();
    this->showHome();
    ui->action_Home->setEnabled(false);
}
void CJWindow::on_actionCLEAR_triggered()
{
    //this->clearHome();
    this->cjTest3->timer->start(200);
}

void CJWindow::on_action_test1_triggered()
{
    this->clearHome();

    showTest1();
    ui->action_test1->setEnabled(false);
}
void CJWindow::on_actionTest_2_triggered()
{
    this->clearHome();
    showTest2();
    ui->actionTest_2->setEnabled(false);
}

void CJWindow::on_actionTest_3_triggered()
{
    this->clearHome();
    showTest3();
    ui->actionTest_3->setEnabled(false);
}

void CJWindow::on_actionTest_4_triggered()
{
    this->clearHome();
    showTest4();
    ui->actionTest_4->setEnabled(false);
}

void CJWindow::on_actionTest_5_triggered()
{
    this->clearHome();
    showTest5();
    ui->actionTest_5->setEnabled(false);
}

void CJWindow::on_actionTest1_2_triggered()
{
    this->clearHome();
    showTest1_2();
    ui->actionTest1_2->setEnabled(false);
}
