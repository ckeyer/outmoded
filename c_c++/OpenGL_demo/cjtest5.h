#ifndef CJTEST5_H
#define CJTEST5_H

#include <QWidget>
#include <QGridLayout>
#include <QScrollArea>
#include <QDial>
#include <QLabel>
#include "cjtest5gl.h"

class CJTest5 : public QWidget
{
    Q_OBJECT
public:
    explicit CJTest5(QWidget *parent = 0);
    ~CJTest5();
private:
    CJTest5GL *test5gl;
    QDial *dialxspeed;
    QDial *dialyspeed;
    QDial *dialzspeed;
    QDial *dialpoints;
signals:

public slots:

};

#endif // CJTEST5_H
