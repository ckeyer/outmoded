#ifndef CJWINDOW_H
#define CJWINDOW_H

#include <QMainWindow>
#include <QMessageBox>
#include "glwidget.h"
#include "cjtest1.h"
#include "cjtest1_2.h"
#include "cjtest2.h"
#include "cjtest3.h"
#include "cjtest4.h"
#include "cjtest5.h"

namespace Ui {
class CJWindow;
}

class CJWindow : public QMainWindow
{
    enum UI_STATUS{
        NOTHING,
        HOME,
        TEST1,
        TEST1_2,
        TEST2,
        TEST3,
        TEST4,
        TEST5
    };

    Q_OBJECT

public:
    explicit CJWindow(QWidget *parent = 0);
    ~CJWindow();
    void init();
    void clearHome();
    void showHome();
    void showTest1();
    void showTest1_2();
    void showTest2();
    void showTest3();
    void showTest4();
    void showTest5();
    QMessageBox testBox;
    GLWidget *glWidgetHome;
    CJTest1 *cjTest1;
    CJTest1_2 *cjTest1_2;
    CJTest2 *cjTest2;
    CJTest3 *cjTest3;
    CJTest4 *cjTest4;
    CJTest5 *cjTest5;

private slots:
    void on_action_test1_triggered();

    void on_action_Home_triggered();

    void on_actionCLEAR_triggered();

    void on_actionTest_2_triggered();

    void on_actionTest_3_triggered();

    void on_actionTest_4_triggered();

    void on_actionTest_5_triggered();

    void on_actionTest1_2_triggered();

private:
    Ui::CJWindow *ui;
    UI_STATUS uiStatus;
};

#endif // CJWINDOW_H
