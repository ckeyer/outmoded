/****************************************************************************
** Meta object code from reading C++ file 'cjwindow.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.3.2)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../../OpenGL_demo/cjwindow.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'cjwindow.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.3.2. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_CJWindow_t {
    QByteArrayData data[7];
    char stringdata[138];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_CJWindow_t, stringdata) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_CJWindow_t qt_meta_stringdata_CJWindow = {
    {
QT_MOC_LITERAL(0, 0, 8),
QT_MOC_LITERAL(1, 9, 25),
QT_MOC_LITERAL(2, 35, 0),
QT_MOC_LITERAL(3, 36, 24),
QT_MOC_LITERAL(4, 61, 24),
QT_MOC_LITERAL(5, 86, 25),
QT_MOC_LITERAL(6, 112, 25)
    },
    "CJWindow\0on_action_test1_triggered\0\0"
    "on_action_Home_triggered\0"
    "on_actionCLEAR_triggered\0"
    "on_actionTest_2_triggered\0"
    "on_actionTest_3_triggered"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_CJWindow[] = {

 // content:
       7,       // revision
       0,       // classname
       0,    0, // classinfo
       5,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: name, argc, parameters, tag, flags
       1,    0,   39,    2, 0x08 /* Private */,
       3,    0,   40,    2, 0x08 /* Private */,
       4,    0,   41,    2, 0x08 /* Private */,
       5,    0,   42,    2, 0x08 /* Private */,
       6,    0,   43,    2, 0x08 /* Private */,

 // slots: parameters
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,

       0        // eod
};

void CJWindow::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        CJWindow *_t = static_cast<CJWindow *>(_o);
        switch (_id) {
        case 0: _t->on_action_test1_triggered(); break;
        case 1: _t->on_action_Home_triggered(); break;
        case 2: _t->on_actionCLEAR_triggered(); break;
        case 3: _t->on_actionTest_2_triggered(); break;
        case 4: _t->on_actionTest_3_triggered(); break;
        default: ;
        }
    }
    Q_UNUSED(_a);
}

const QMetaObject CJWindow::staticMetaObject = {
    { &QMainWindow::staticMetaObject, qt_meta_stringdata_CJWindow.data,
      qt_meta_data_CJWindow,  qt_static_metacall, 0, 0}
};


const QMetaObject *CJWindow::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *CJWindow::qt_metacast(const char *_clname)
{
    if (!_clname) return 0;
    if (!strcmp(_clname, qt_meta_stringdata_CJWindow.stringdata))
        return static_cast<void*>(const_cast< CJWindow*>(this));
    return QMainWindow::qt_metacast(_clname);
}

int CJWindow::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QMainWindow::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 5)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 5;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 5)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 5;
    }
    return _id;
}
QT_END_MOC_NAMESPACE
