#ifndef CJTEST4_H
#define CJTEST4_H

#include <QWidget>
#include <QGridLayout>
#include <QScrollArea>
#include <QDial>
#include <QLabel>
#include "cjtest4gl.h"

class CJTest4 : public QWidget
{
    Q_OBJECT
public:
    explicit CJTest4(QWidget *parent = 0);
    ~CJTest4();
    QDial *dial;
    QDial *dialxspeed;
    QDial *dialyspeed;
private:
    QLabel *label;
    CJTest4GL *test4gl;
signals:

public slots:

};

#endif // CJTEST4_H
