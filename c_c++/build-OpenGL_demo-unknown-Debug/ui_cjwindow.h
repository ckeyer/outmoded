/********************************************************************************
** Form generated from reading UI file 'cjwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.3.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CJWINDOW_H
#define UI_CJWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenu>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QScrollArea>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_CJWindow
{
public:
    QAction *action_test1;
    QAction *action_Home;
    QAction *actionCLEAR;
    QAction *actionTest_2;
    QAction *actionTest_3;
    QWidget *centralWidget;
    QGridLayout *gridLayout_2;
    QGridLayout *gridLayout_home;
    QScrollArea *scrollArea_home;
    QWidget *scrollArea_homeWidgetContents;
    QMenuBar *menuBar;
    QMenu *menu_About;
    QMenu *menuFile;
    QMenu *menuTEST;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *CJWindow)
    {
        if (CJWindow->objectName().isEmpty())
            CJWindow->setObjectName(QStringLiteral("CJWindow"));
        CJWindow->resize(592, 360);
        action_test1 = new QAction(CJWindow);
        action_test1->setObjectName(QStringLiteral("action_test1"));
        action_Home = new QAction(CJWindow);
        action_Home->setObjectName(QStringLiteral("action_Home"));
        action_Home->setEnabled(true);
        actionCLEAR = new QAction(CJWindow);
        actionCLEAR->setObjectName(QStringLiteral("actionCLEAR"));
        actionTest_2 = new QAction(CJWindow);
        actionTest_2->setObjectName(QStringLiteral("actionTest_2"));
        actionTest_3 = new QAction(CJWindow);
        actionTest_3->setObjectName(QStringLiteral("actionTest_3"));
        centralWidget = new QWidget(CJWindow);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        gridLayout_2 = new QGridLayout(centralWidget);
        gridLayout_2->setSpacing(6);
        gridLayout_2->setContentsMargins(11, 11, 11, 11);
        gridLayout_2->setObjectName(QStringLiteral("gridLayout_2"));
        gridLayout_home = new QGridLayout();
        gridLayout_home->setSpacing(6);
        gridLayout_home->setObjectName(QStringLiteral("gridLayout_home"));
        gridLayout_home->setSizeConstraint(QLayout::SetNoConstraint);
        scrollArea_home = new QScrollArea(centralWidget);
        scrollArea_home->setObjectName(QStringLiteral("scrollArea_home"));
        scrollArea_home->setWidgetResizable(true);
        scrollArea_homeWidgetContents = new QWidget();
        scrollArea_homeWidgetContents->setObjectName(QStringLiteral("scrollArea_homeWidgetContents"));
        scrollArea_homeWidgetContents->setGeometry(QRect(0, 0, 570, 275));
        scrollArea_home->setWidget(scrollArea_homeWidgetContents);

        gridLayout_home->addWidget(scrollArea_home, 0, 0, 1, 1);


        gridLayout_2->addLayout(gridLayout_home, 0, 0, 1, 1);

        CJWindow->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(CJWindow);
        menuBar->setObjectName(QStringLiteral("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 592, 28));
        menu_About = new QMenu(menuBar);
        menu_About->setObjectName(QStringLiteral("menu_About"));
        menuFile = new QMenu(menuBar);
        menuFile->setObjectName(QStringLiteral("menuFile"));
        menuTEST = new QMenu(menuBar);
        menuTEST->setObjectName(QStringLiteral("menuTEST"));
        CJWindow->setMenuBar(menuBar);
        mainToolBar = new QToolBar(CJWindow);
        mainToolBar->setObjectName(QStringLiteral("mainToolBar"));
        CJWindow->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(CJWindow);
        statusBar->setObjectName(QStringLiteral("statusBar"));
        CJWindow->setStatusBar(statusBar);

        menuBar->addAction(menuFile->menuAction());
        menuBar->addAction(menu_About->menuAction());
        menuBar->addAction(menuTEST->menuAction());
        menuFile->addAction(action_Home);
        menuFile->addAction(action_test1);
        menuFile->addAction(actionTest_2);
        menuFile->addAction(actionTest_3);
        menuTEST->addAction(actionCLEAR);

        retranslateUi(CJWindow);

        QMetaObject::connectSlotsByName(CJWindow);
    } // setupUi

    void retranslateUi(QMainWindow *CJWindow)
    {
        CJWindow->setWindowTitle(QApplication::translate("CJWindow", "CJWindow", 0));
        action_test1->setText(QApplication::translate("CJWindow", "Test&1", 0));
        action_test1->setShortcut(QApplication::translate("CJWindow", "Ctrl+1", 0));
        action_Home->setText(QApplication::translate("CJWindow", "&Home", 0));
        action_Home->setShortcut(QApplication::translate("CJWindow", "Ctrl+H", 0));
        actionCLEAR->setText(QApplication::translate("CJWindow", "CLEAR", 0));
        actionTest_2->setText(QApplication::translate("CJWindow", "Test&2", 0));
        actionTest_3->setText(QApplication::translate("CJWindow", "Test&3", 0));
        menu_About->setTitle(QApplication::translate("CJWindow", "&About", 0));
        menuFile->setTitle(QApplication::translate("CJWindow", "&File", 0));
        menuTEST->setTitle(QApplication::translate("CJWindow", "TEST", 0));
    } // retranslateUi

};

namespace Ui {
    class CJWindow: public Ui_CJWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CJWINDOW_H
