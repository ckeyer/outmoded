#include "cjtest4.h"

CJTest4::CJTest4(QWidget *parent) :
    QWidget(parent)
{
    dial = new QDial(0);
    label = new QLabel;
    QGridLayout *centralLayout = new QGridLayout;
    QScrollArea *glWidgetArea = new QScrollArea ;
    centralLayout->addWidget(dial, 0, 0);
    centralLayout->addWidget(label, 1, 0);
    centralLayout->addWidget(glWidgetArea, 0, 1,2,2,0);

    label->setText(tr("Hello World"));
//    dial->setMaximumHeight(20);
    label->setMaximumWidth(80);
    dial->setMaximumWidth(80);
    dial->setMaximum(36);
    dial->setMinimum(3);

    this->setLayout(centralLayout);

    this->test4gl = new CJTest4GL();
    glWidgetArea->setWidget(test4gl);
    glWidgetArea->setWidgetResizable(true);
    glWidgetArea->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    glWidgetArea->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    glWidgetArea->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    glWidgetArea->setMinimumSize(50, 50);

    connect(this->dial,SIGNAL(valueChanged(int)),this->label,SLOT(setNum(int)));
    connect(this->dial,SIGNAL(valueChanged(int)),this->test4gl,SLOT(chageCountPoints(int)));

}
CJTest4::~CJTest4()
{
    test4gl->~CJTest4GL();
    label->close();
    dial->close();

}
