/********************************************************************************
** Form generated from reading UI file 'Forms.ui'
**
** Created: Thu May 20 09:24:48 2010
**      by: Qt User Interface Compiler version 4.6.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_FORMS_H
#define UI_FORMS_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QGroupBox>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Form
{
public:
    QGroupBox *grpForm;
    QLabel *lblForm;
    QLineEdit *txtForm;

    void setupUi(QWidget *Form)
    {
        if (Form->objectName().isEmpty())
            Form->setObjectName(QString::fromUtf8("Form"));
        Form->resize(354, 71);
        grpForm = new QGroupBox(Form);
        grpForm->setObjectName(QString::fromUtf8("grpForm"));
        grpForm->setGeometry(QRect(10, 0, 341, 61));
        lblForm = new QLabel(grpForm);
        lblForm->setObjectName(QString::fromUtf8("lblForm"));
        lblForm->setEnabled(true);
        lblForm->setGeometry(QRect(10, 20, 71, 16));
        txtForm = new QLineEdit(grpForm);
        txtForm->setObjectName(QString::fromUtf8("txtForm"));
        txtForm->setEnabled(true);
        txtForm->setGeometry(QRect(80, 20, 251, 20));

        retranslateUi(Form);

        QMetaObject::connectSlotsByName(Form);
    } // setupUi

    void retranslateUi(QWidget *Form)
    {
        Form->setWindowTitle(QApplication::translate("Form", "Form", 0, QApplication::UnicodeUTF8));
        grpForm->setTitle(QApplication::translate("Form", "Form", 0, QApplication::UnicodeUTF8));
        lblForm->setText(QApplication::translate("Form", "Name:", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class Form: public Ui_Form {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_FORMS_H
