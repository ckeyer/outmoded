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
    QDial *dial;
    QDial *dialxspeed;
    QDial *dialyspeed;
private:
    QLabel *label;
    CJTest5GL *test5gl;
signals:

public slots:

};

#endif // CJTEST5_H
