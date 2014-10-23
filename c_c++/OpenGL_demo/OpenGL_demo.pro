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
    glwidget.cpp

HEADERS  += cjwindow.h \
    glwidget.h

FORMS    += cjwindow.ui
