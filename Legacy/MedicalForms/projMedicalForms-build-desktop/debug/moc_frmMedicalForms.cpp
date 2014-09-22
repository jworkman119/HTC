/****************************************************************************
** Meta object code from reading C++ file 'frmMedicalForms.h'
**
** Created: Fri Dec 10 16:00:06 2010
**      by: The Qt Meta Object Compiler version 62 (Qt 4.7.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../../projMedicalForms/frmMedicalForms.h"
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'frmMedicalForms.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 62
#error "This file was generated using the moc from 4.7.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
static const uint qt_meta_data_frmMedicalForms[] = {

 // content:
       5,       // revision
       0,       // classname
       0,    0, // classinfo
       8,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: signature, parameters, type, tag, flags
      23,   17,   16,   16, 0x08,
      66,   16,   16,   16, 0x08,
      94,   16,   16,   16, 0x08,
     116,   16,   16,   16, 0x08,
     141,   16,   16,   16, 0x08,
     173,   16,   16,   16, 0x08,
     199,   16,   16,   16, 0x08,
     221,   16,   16,   16, 0x08,

       0        // eod
};

static const char qt_meta_stringdata_frmMedicalForms[] = {
    "frmMedicalForms\0\0index\0"
    "on_lstQuestions_doubleClicked(QModelIndex)\0"
    "on_chkSubQuestion_clicked()\0"
    "on_butEnter_clicked()\0on_butAdd2List_clicked()\0"
    "on_txtForm_textChanged(QString)\0"
    "on_optQuestions_clicked()\0"
    "on_optForms_clicked()\0on_butClose_clicked()\0"
};

const QMetaObject frmMedicalForms::staticMetaObject = {
    { &QMainWindow::staticMetaObject, qt_meta_stringdata_frmMedicalForms,
      qt_meta_data_frmMedicalForms, 0 }
};

#ifdef Q_NO_DATA_RELOCATION
const QMetaObject &frmMedicalForms::getStaticMetaObject() { return staticMetaObject; }
#endif //Q_NO_DATA_RELOCATION

const QMetaObject *frmMedicalForms::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->metaObject : &staticMetaObject;
}

void *frmMedicalForms::qt_metacast(const char *_clname)
{
    if (!_clname) return 0;
    if (!strcmp(_clname, qt_meta_stringdata_frmMedicalForms))
        return static_cast<void*>(const_cast< frmMedicalForms*>(this));
    return QMainWindow::qt_metacast(_clname);
}

int frmMedicalForms::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QMainWindow::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        switch (_id) {
        case 0: on_lstQuestions_doubleClicked((*reinterpret_cast< QModelIndex(*)>(_a[1]))); break;
        case 1: on_chkSubQuestion_clicked(); break;
        case 2: on_butEnter_clicked(); break;
        case 3: on_butAdd2List_clicked(); break;
        case 4: on_txtForm_textChanged((*reinterpret_cast< QString(*)>(_a[1]))); break;
        case 5: on_optQuestions_clicked(); break;
        case 6: on_optForms_clicked(); break;
        case 7: on_butClose_clicked(); break;
        default: ;
        }
        _id -= 8;
    }
    return _id;
}
QT_END_MOC_NAMESPACE
