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
    this->showTest2();
}

void CJWindow::clearHome()
{
    switch (uiStatus) {
    case HOME:
        this->glWidgetHome->~GLWidget();
        glWidgetHome=NULL;
        break;
    case TEST1:
        this->cjTest1->~CJTest1();
        cjTest1=NULL;
        break;
    case TEST2:
        this->cjTest2->~CJTest2();
        cjTest2=NULL;
        break;
    default:
        break;
    }
    uiStatus = NOTHING;
    ui->action_Home->setEnabled(true);
    ui->action_test1->setEnabled(true);
    ui->actionTest_2->setEnabled(true);
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

void CJWindow::on_action_Home_triggered()
{
    this->clearHome();
    this->showHome();
    ui->action_Home->setEnabled(false);
}
void CJWindow::on_actionCLEAR_triggered()
{
    this->clearHome();
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
