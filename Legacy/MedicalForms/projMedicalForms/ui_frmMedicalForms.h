/********************************************************************************
** Form generated from reading UI file 'frmMedicalForms.ui'
**
** Created: Tue Jun 1 12:01:09 2010
**      by: Qt User Interface Compiler version 4.6.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_FRMMEDICALFORMS_H
#define UI_FRMMEDICALFORMS_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QCheckBox>
#include <QtGui/QComboBox>
#include <QtGui/QGroupBox>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QMainWindow>
#include <QtGui/QPushButton>
#include <QtGui/QRadioButton>
#include <QtGui/QStatusBar>
#include <QtGui/QToolBar>
#include <QtGui/QTreeWidget>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_frmMedicalForms
{
public:
    QWidget *centralWidget;
    QRadioButton *optForms;
    QRadioButton *optQuestions;
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
    QTreeWidget *lstQuestions;
    QCheckBox *chkSubQuestion;
    QGroupBox *grpForm;
    QLabel *lblForm;
    QLineEdit *txtForm;
    QPushButton *butClose;
    QPushButton *butEnter;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *frmMedicalForms)
    {
        if (frmMedicalForms->objectName().isEmpty())
            frmMedicalForms->setObjectName(QString::fromUtf8("frmMedicalForms"));
        frmMedicalForms->resize(435, 454);
        centralWidget = new QWidget(frmMedicalForms);
        centralWidget->setObjectName(QString::fromUtf8("centralWidget"));
        optForms = new QRadioButton(centralWidget);
        optForms->setObjectName(QString::fromUtf8("optForms"));
        optForms->setGeometry(QRect(100, 10, 101, 17));
        optQuestions = new QRadioButton(centralWidget);
        optQuestions->setObjectName(QString::fromUtf8("optQuestions"));
        optQuestions->setGeometry(QRect(240, 10, 111, 17));
        grpQuestions = new QGroupBox(centralWidget);
        grpQuestions->setObjectName(QString::fromUtf8("grpQuestions"));
        grpQuestions->setGeometry(QRect(20, 30, 371, 331));
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
        lblSubQuestion->setGeometry(QRect(20, 270, 71, 16));
        txtSubQuestion = new QLineEdit(grpQuestions);
        txtSubQuestion->setObjectName(QString::fromUtf8("txtSubQuestion"));
        txtSubQuestion->setGeometry(QRect(100, 270, 251, 20));
        butAdd2List = new QPushButton(grpQuestions);
        butAdd2List->setObjectName(QString::fromUtf8("butAdd2List"));
        butAdd2List->setGeometry(QRect(180, 300, 75, 23));
        lstQuestions = new QTreeWidget(grpQuestions);
        QTreeWidgetItem *__qtreewidgetitem = new QTreeWidgetItem();
        __qtreewidgetitem->setText(1, QString::fromUtf8("2"));
        __qtreewidgetitem->setText(0, QString::fromUtf8("1"));
        lstQuestions->setHeaderItem(__qtreewidgetitem);
        lstQuestions->setObjectName(QString::fromUtf8("lstQuestions"));
        lstQuestions->setGeometry(QRect(100, 50, 256, 121));
        lstQuestions->setColumnCount(2);
        chkSubQuestion = new QCheckBox(grpQuestions);
        chkSubQuestion->setObjectName(QString::fromUtf8("chkSubQuestion"));
        chkSubQuestion->setGeometry(QRect(20, 240, 91, 17));
        grpForm = new QGroupBox(centralWidget);
        grpForm->setObjectName(QString::fromUtf8("grpForm"));
        grpForm->setGeometry(QRect(20, 30, 331, 51));
        lblForm = new QLabel(grpForm);
        lblForm->setObjectName(QString::fromUtf8("lblForm"));
        lblForm->setEnabled(true);
        lblForm->setGeometry(QRect(10, 20, 71, 16));
        txtForm = new QLineEdit(grpForm);
        txtForm->setObjectName(QString::fromUtf8("txtForm"));
        txtForm->setEnabled(true);
        txtForm->setGeometry(QRect(50, 20, 251, 20));
        butClose = new QPushButton(centralWidget);
        butClose->setObjectName(QString::fromUtf8("butClose"));
        butClose->setGeometry(QRect(240, 380, 75, 23));
        butClose->setDefault(false);
        butEnter = new QPushButton(centralWidget);
        butEnter->setObjectName(QString::fromUtf8("butEnter"));
        butEnter->setEnabled(false);
        butEnter->setGeometry(QRect(140, 380, 75, 23));
        butEnter->setDefault(true);
        frmMedicalForms->setCentralWidget(centralWidget);
        mainToolBar = new QToolBar(frmMedicalForms);
        mainToolBar->setObjectName(QString::fromUtf8("mainToolBar"));
        frmMedicalForms->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(frmMedicalForms);
        statusBar->setObjectName(QString::fromUtf8("statusBar"));
        frmMedicalForms->setStatusBar(statusBar);
        QWidget::setTabOrder(optForms, optQuestions);
        QWidget::setTabOrder(optQuestions, txtForm);
        QWidget::setTabOrder(txtForm, cmbForm);
        QWidget::setTabOrder(cmbForm, txtQuestion);
        QWidget::setTabOrder(txtQuestion, cmbType);
        QWidget::setTabOrder(cmbType, txtSubQuestion);
        QWidget::setTabOrder(txtSubQuestion, butAdd2List);

        retranslateUi(frmMedicalForms);

        QMetaObject::connectSlotsByName(frmMedicalForms);
    } // setupUi

    void retranslateUi(QMainWindow *frmMedicalForms)
    {
        frmMedicalForms->setWindowTitle(QApplication::translate("frmMedicalForms", "Enter Medical Forms", 0, QApplication::UnicodeUTF8));
        optForms->setText(QApplication::translate("frmMedicalForms", "Enter Forms", 0, QApplication::UnicodeUTF8));
        optQuestions->setText(QApplication::translate("frmMedicalForms", "Enter Questions", 0, QApplication::UnicodeUTF8));
        grpQuestions->setTitle(QApplication::translate("frmMedicalForms", "Questions", 0, QApplication::UnicodeUTF8));
        lblForms->setText(QApplication::translate("frmMedicalForms", "Form:", 0, QApplication::UnicodeUTF8));
        lblQuestion->setText(QApplication::translate("frmMedicalForms", "Question:", 0, QApplication::UnicodeUTF8));
        lblType->setText(QApplication::translate("frmMedicalForms", "Type:", 0, QApplication::UnicodeUTF8));
        lblSubQuestion->setText(QApplication::translate("frmMedicalForms", "Sub-Question:", 0, QApplication::UnicodeUTF8));
        butAdd2List->setText(QApplication::translate("frmMedicalForms", "Add To List", 0, QApplication::UnicodeUTF8));
        chkSubQuestion->setText(QApplication::translate("frmMedicalForms", "Sub-Question", 0, QApplication::UnicodeUTF8));
        grpForm->setTitle(QApplication::translate("frmMedicalForms", "Form", 0, QApplication::UnicodeUTF8));
        lblForm->setText(QApplication::translate("frmMedicalForms", "Name:", 0, QApplication::UnicodeUTF8));
        butClose->setText(QApplication::translate("frmMedicalForms", "Close", 0, QApplication::UnicodeUTF8));
        butEnter->setText(QApplication::translate("frmMedicalForms", "Enter", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class frmMedicalForms: public Ui_frmMedicalForms {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_FRMMEDICALFORMS_H
