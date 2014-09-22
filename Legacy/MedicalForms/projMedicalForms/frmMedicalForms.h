#ifndef FRMMEDICALFORMS_H
#define FRMMEDICALFORMS_H

#include <QMainWindow>
#include <QListWidget>
#include <QSqlDatabase>
#include <QMessageBox>
#include <QSqlQuery>

#include <QDebug>

namespace Ui {
    class frmMedicalForms;
}

class frmMedicalForms : public QMainWindow {
    Q_OBJECT
public:
    frmMedicalForms(QWidget *parent = 0);
    ~frmMedicalForms();

protected:
    void changeEvent(QEvent *e);

private:
    Ui::frmMedicalForms *ui;
    void resizeWindow(int, int);
    void setUpMainWindow();
    bool ConnectToDB(QString, QSqlDatabase &);
    bool UpdateDatabase(QString, QString);
    void CleanUpForm();
    void Clean_grpQuestions();
    void QueryInsertDB(QString);
    QSqlQuery QueryDB(QString);
    void updateDB_Questions();

private slots:

    void on_lstQuestions_doubleClicked(QModelIndex index);
    void on_chkSubQuestion_clicked();
    void on_butEnter_clicked();
    void on_butAdd2List_clicked();
    void on_txtForm_textChanged(QString );
    void on_optQuestions_clicked();
    void on_optForms_clicked();
    void on_butClose_clicked();


};

#endif // FRMMEDICALFORMS_H
