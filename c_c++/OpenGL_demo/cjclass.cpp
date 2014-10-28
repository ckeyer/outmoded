#include "cjclass.h"

CJClass::CJClass()
{
}

void CJClass::showMsg(QString msg)
{
    QMessageBox::information(0,"CJ_Studio",msg,0,0);
}
void CJClass::showMsg(QString msg, QString title)
{
    QMessageBox::information(0,title,msg);
}
