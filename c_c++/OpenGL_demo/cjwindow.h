#ifndef CJWINDOW_H
#define CJWINDOW_H

#include <QMainWindow>
#include <QMessageBox>
#include "glwidget.h"
#include "cjtest1.h"
#include "cjtest2.h"
#include "cjtest3.h"

namespace Ui {
class CJWindow;
}

class CJWindow : public QMainWindow
{
    enum UI_STATUS{
        NOTHING,
        HOME,
        TEST1,
        TEST2,
        TEST3
    };

    Q_OBJECT

public:
    explicit CJWindow(QWidget *parent = 0);
    ~CJWindow();
    void init();
    void clearHome();
    void showHome();
    void showTest1();
    void showTest2();
    void showTest3();
    QMessageBox testBox;
    GLWidget *glWidgetHome;
    CJTest1 *cjTest1;
    CJTest2 *cjTest2;
    CJTest3 *cjTest3;

private slots:
    void on_action_test1_triggered();

    void on_action_Home_triggered();

    void on_actionCLEAR_triggered();

    void on_actionTest_2_triggered();

    void on_actionTest_3_triggered();

private:
    Ui::CJWindow *ui;
    UI_STATUS uiStatus;
};

#endif // CJWINDOW_H
