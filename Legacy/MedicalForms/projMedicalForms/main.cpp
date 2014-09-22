#include <QtGui/QApplication>
#include "frmMedicalForms.h"

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    frmMedicalForms w;
    w.show();
    return a.exec();
}
