#include "cjwindow.h"
#include "ui_cjwindow.h"

CJWindow::CJWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::CJWindow)
{
    ui->setupUi(this);
    this->init();
}
CJWindow::~CJWindow()
{
    delete ui;
}
void CJWindow::init()
{
    this->showHome();
}

void CJWindow::showHome()
{
    glWidgetHome = new GLWidget;
    ui->scrollArea_home->setWidget(glWidgetHome);
    ui->scrollArea_home->setWidgetResizable(true);
    ui->scrollArea_home->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->scrollArea_home->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    ui->scrollArea_home->setMinimumSize(50, 50);
}
void CJWindow::clearHome()
{
    this->glWidgetHome->close();
    ui->scrollArea_home->clearFocus();
}

void CJWindow::on_action_Home_triggered()
{
    this->clearHome();
    this->showHome();
    ui->action_Home->setEnabled(false);
}
void CJWindow::on_action_test1_triggered()
{
    this->clearHome();
    ui->action_Home->setEnabled(true);
}
