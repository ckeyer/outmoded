TEMPLATE = app
CONFIG += console
CONFIG -= app_bundle
CONFIG -= qt

SOURCES += main.cpp \
    employee.cpp \
    money.cpp \
    worker.cpp \
    manager.cpp \
    saler.cpp \
    employeemanager.cpp

include(deployment.pri)
qtcAddDeployment()

HEADERS += \
    employee.h \
    money.h \
    worker.h \
    manager.h \
    saler.h \
    employeemanager.h \
    test.h

