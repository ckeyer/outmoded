#-------------------------------------------------
#
# Project created by QtCreator 2014-10-23T22:00:28
#
#-------------------------------------------------

QT       += core gui opengl

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = OpenGL_demo
TEMPLATE = app


SOURCES += main.cpp\
        cjwindow.cpp \
    glwidget.cpp \
    cjtest1.cpp \
    cjtest2.cpp \
    cjtest3.cpp \
    cjclass.cpp

HEADERS  += cjwindow.h \
    glwidget.h \
    cjtest1.h \
    cjtest2.h \
    cjtest3.h \
    cjclass.h

FORMS    += cjwindow.ui
