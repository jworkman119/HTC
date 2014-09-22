/********************************************************************************
** Form generated from reading UI file 'Questions.ui'
**
** Created: Thu May 20 09:24:48 2010
**      by: Qt User Interface Compiler version 4.6.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_QUESTIONS_H
#define UI_QUESTIONS_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QComboBox>
#include <QtGui/QGroupBox>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QListWidget>
#include <QtGui/QPushButton>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Form
{
public:
    QGroupBox *grpQuestions;
    QLabel *lblForms;
    QComboBox *cmbForm;
    QLineEdit *txtQuestion;
    QLabel *lblQuestion;
    QComboBox *cmbType;
    QLabel *lblType;
    QLabel *lblSubQuestion;
    QLineEdit *txtSubQuestion;
    QPushButton *butAdd2List;
    QListWidget *lstQuestions;

    void setupUi(QWidget *Form)
    {
        if (Form->objectName().isEmpty())
            Form->setObjectName(QString::fromUtf8("Form"));
        Form->resize(385, 316);
        grpQuestions = new QGroupBox(Form);
        grpQuestions->setObjectName(QString::fromUtf8("grpQuestions"));
        grpQuestions->setGeometry(QRect(10, 0, 371, 311));
        lblForms = new QLabel(grpQuestions);
        lblForms->setObjectName(QString::fromUtf8("lblForms"));
        lblForms->setGeometry(QRect(20, 20, 46, 13));
        cmbForm = new QComboBox(grpQuestions);
        cmbForm->setObjectName(QString::fromUtf8("cmbForm"));
        cmbForm->setGeometry(QRect(100, 20, 251, 22));
        txtQuestion = new QLineEdit(grpQuestions);
        txtQuestion->setObjectName(QString::fromUtf8("txtQuestion"));
        txtQuestion->setGeometry(QRect(100, 180, 251, 20));
        lblQuestion = new QLabel(grpQuestions);
        lblQuestion->setObjectName(QString::fromUtf8("lblQuestion"));
        lblQuestion->setGeometry(QRect(20, 180, 46, 13));
        cmbType = new QComboBox(grpQuestions);
        cmbType->setObjectName(QString::fromUtf8("cmbType"));
        cmbType->setGeometry(QRect(100, 210, 251, 22));
        lblType = new QLabel(grpQuestions);
        lblType->setObjectName(QString::fromUtf8("lblType"));
        lblType->setGeometry(QRect(20, 210, 46, 13));
        lblSubQuestion = new QLabel(grpQuestions);
        lblSubQuestion->setObjectName(QString::fromUtf8("lblSubQuestion"));
        lblSubQuestion->setGeometry(QRect(20, 240, 71, 16));
        txtSubQuestion = new QLineEdit(grpQuestions);
        txtSubQuestion->setObjectName(QString::fromUtf8("txtSubQuestion"));
        txtSubQuestion->setGeometry(QRect(100, 240, 251, 20));
        butAdd2List = new QPushButton(grpQuestions);
        butAdd2List->setObjectName(QString::fromUtf8("butAdd2List"));
        butAdd2List->setGeometry(QRect(180, 270, 75, 23));
        lstQuestions = new QListWidget(grpQuestions);
        lstQuestions->setObjectName(QString::fromUtf8("lstQuestions"));
        lstQuestions->setGeometry(QRect(100, 50, 251, 121));

        retranslateUi(Form);

        QMetaObject::connectSlotsByName(Form);
    } // setupUi

    void retranslateUi(QWidget *Form)
    {
        Form->setWindowTitle(QApplication::translate("Form", "Form", 0, QApplication::UnicodeUTF8));
        grpQuestions->setTitle(QApplication::translate("Form", "Questions", 0, QApplication::UnicodeUTF8));
        lblForms->setText(QApplication::translate("Form", "Form:", 0, QApplication::UnicodeUTF8));
        lblQuestion->setText(QApplication::translate("Form", "Question:", 0, QApplication::UnicodeUTF8));
        lblType->setText(QApplication::translate("Form", "Type:", 0, QApplication::UnicodeUTF8));
        lblSubQuestion->setText(QApplication::translate("Form", "Sub-question:", 0, QApplication::UnicodeUTF8));
        butAdd2List->setText(QApplication::translate("Form", "Add To List", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class Form: public Ui_Form {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_QUESTIONS_H
