#ifndef CJWINDOW_H
#define CJWINDOW_H

#include <QMainWindow>
#include "glwidget.h"

namespace Ui {
class CJWindow;
}

class CJWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit CJWindow(QWidget *parent = 0);
    ~CJWindow();
    void init();
    void clearHome();
    void showHome();
    GLWidget *glWidgetHome;

private slots:
    void on_action_test1_triggered();

    void on_action_Home_triggered();

private:
    Ui::CJWindow *ui;
};

#endif // CJWINDOW_H
