#include "cjtest5.h"

CJTest5::CJTest5(QWidget *parent) :
    QWidget(parent)
{
    dial = new QDial(0);
    dialxspeed = new QDial(0);
    dialyspeed = new QDial(0);
    label = new QLabel;
    QGridLayout *centralLayout = new QGridLayout;
    QScrollArea *glWidgetArea = new QScrollArea ;
    centralLayout->addWidget(dial, 0, 0);
    //centralLayout->addWidget(label, 1, 0);
    centralLayout->addWidget(dialxspeed, 1, 0);
    centralLayout->addWidget(dialyspeed, 2, 0);
    centralLayout->addWidget(glWidgetArea, 0, 1,3,3,0);

    label->setText(tr("Hello World"));
//    dial->setMaximumHeight(20);
//    label->setMaximumWidth(80);
    dial->setMaximumWidth(80);
    dialyspeed->setMaximumWidth(80);
    dialxspeed->setMaximumWidth(80);
    dial->setMaximum(8);
    dial->setMinimum(-8);
    dialxspeed->setMaximum(8);
    dialxspeed->setMinimum(-8);
    dialyspeed->setMaximum(8);
    dialyspeed->setMinimum(-8);

    this->setLayout(centralLayout);

    this->test5gl = new CJTest5GL();
    glWidgetArea->setWidget(test5gl);
    glWidgetArea->setWidgetResizable(true);
    glWidgetArea->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    glWidgetArea->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    glWidgetArea->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    glWidgetArea->setMinimumSize(50, 50);

//    connect(this->dial,SIGNAL(valueChanged(int)),this->label,SLOT(setNum(int)));
    connect(this->dial,SIGNAL(valueChanged(int)),this->test5gl,SLOT(chageXSpeed(int)));
    connect(this->dialxspeed,SIGNAL(valueChanged(int)),this->test5gl,SLOT(chageYSpeed(int)));
    connect(this->dialyspeed,SIGNAL(valueChanged(int)),this->test5gl,SLOT(chageZSpeed(int)));
}
CJTest5::~CJTest5()
{
    test5gl->~CJTest5GL();
    label->close();
    dial->close();
}
