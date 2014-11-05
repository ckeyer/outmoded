#include "cjtest5.h"

CJTest5::CJTest5(QWidget *parent) :
    QWidget(parent)
{
    dialxspeed = new QDial(0);
    dialyspeed = new QDial(0);
    dialzspeed = new QDial(0);
    dialpoints = new QDial(0);
    QGridLayout *centralLayout = new QGridLayout;
    QScrollArea *glWidgetArea = new QScrollArea ;
    centralLayout->addWidget(dialpoints, 0, 0);
    centralLayout->addWidget(dialxspeed, 1, 0);
    centralLayout->addWidget(dialyspeed, 2, 0);
    centralLayout->addWidget(dialzspeed, 3, 0);
    centralLayout->addWidget(glWidgetArea, 0, 1,4,4,0);

//    dial->setMaximumHeight(20);
//    label->setMaximumWidth(80);
    dialxspeed->setMaximumWidth(80);
    dialyspeed->setMaximumWidth(80);
    dialzspeed->setMaximumWidth(80);
    dialpoints->setMaximumWidth(80);
    dialpoints->setMaximum(72);
    dialpoints->setMinimum(2);
    dialxspeed->setMaximum(8);
    dialxspeed->setMinimum(-8);
    dialyspeed->setMaximum(8);
    dialyspeed->setMinimum(-8);
    dialzspeed->setMaximum(8);
    dialzspeed->setMinimum(-8);

    this->setLayout(centralLayout);

    this->test5gl = new CJTest5GL();
    glWidgetArea->setWidget(test5gl);
    glWidgetArea->setWidgetResizable(true);
    glWidgetArea->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    glWidgetArea->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    glWidgetArea->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    glWidgetArea->setMinimumSize(50, 50);

//    connect(this->dial,SIGNAL(valueChanged(int)),this->label,SLOT(setNum(int)));
    connect(this->dialpoints,SIGNAL(valueChanged(int)),this->test5gl,SLOT(chagePoints(int)));
    connect(this->dialxspeed,SIGNAL(valueChanged(int)),this->test5gl,SLOT(chageXSpeed(int)));
    connect(this->dialyspeed,SIGNAL(valueChanged(int)),this->test5gl,SLOT(chageYSpeed(int)));
    connect(this->dialzspeed,SIGNAL(valueChanged(int)),this->test5gl,SLOT(chageZSpeed(int)));
}
CJTest5::~CJTest5()
{
    test5gl->~CJTest5GL();
    dialxspeed->close();
    dialyspeed->close();
    dialzspeed->close();
    dialpoints->close();
}
