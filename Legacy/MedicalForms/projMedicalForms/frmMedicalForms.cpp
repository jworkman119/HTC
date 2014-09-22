#include "frmMedicalForms.h"
#include "ui_frmMedicalForms.h"

QWidget *ActiveWidget;

frmMedicalForms::frmMedicalForms(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::frmMedicalForms)
{
    ui->setupUi(this);
    setUpMainWindow();
}

frmMedicalForms::~frmMedicalForms()
{
    delete ui;
}

void frmMedicalForms::changeEvent(QEvent *e)
{
    QMainWindow::changeEvent(e);
    switch (e->type()) {
    case QEvent::LanguageChange:
        ui->retranslateUi(this);
        break;
    default:
        break;
    }
}

void frmMedicalForms::on_butClose_clicked()
{
    this->close();

}

void frmMedicalForms::resizeWindow(int intHeight, int intButHeight){
    QSize objSize;

    objSize = size();
    objSize.setHeight(intHeight);
    resize(objSize.width(),objSize.height());

    //moving buttons
    ui->butClose->move(250,intButHeight);
    ui->butEnter->move(100,intButHeight);

}



void frmMedicalForms::on_optForms_clicked()
{
        ui->grpQuestions->hide();
        resizeWindow(200, 140);
        ui->grpForm->show();
}

void frmMedicalForms::on_optQuestions_clicked()
{
    QString strDB;
    QSqlDatabase db;
    bool blDBConnection;

    ui->grpForm->hide();
    resizeWindow(465,410);
    ui->grpQuestions->show();
    ui->chkSubQuestion->setHidden(true);


    //Reloading cmbForms
    ui->cmbForm->clear();
    strDB = "..\\database\\htcMedicalForms.sqlite";
    blDBConnection = ConnectToDB(strDB, db);
    QSqlQuery query;
    query.exec("SELECT Name FROM Form ORDER BY Name");
    while (query.next())
    {
        ui->cmbForm->addItem(query.value(0).toString());
    }
    db.close();
    ui->cmbForm->setFocus();

}

void frmMedicalForms::on_txtForm_textChanged(QString strText)
{
    if (strText.length() > 0)
    {
        ui->butEnter->setEnabled(true);
    }
    else
    {
        ui->butEnter->setEnabled(false);
    }
}

void frmMedicalForms::on_butAdd2List_clicked()
{
    QTreeWidgetItem *newItem = new QTreeWidgetItem;
    QTreeWidgetItem *childItem = new QTreeWidgetItem;


    if (ui->chkSubQuestion->isChecked() != true){
        newItem->setText(0,ui->txtQuestion->text());
        newItem->setText(1,ui->cmbType->itemText(ui->cmbType->currentIndex()));
        ui->lstQuestions->addTopLevelItem(newItem);
        ui->lstQuestions->setCurrentItem(newItem);

        Clean_grpQuestions();
    }
    else{
        newItem = ui->lstQuestions->currentItem();
        childItem->setText(0,ui->txtSubQuestion->text());
        childItem->setText(1,ui->cmbType->itemText(ui->cmbType->currentIndex()));
        newItem->addChild(childItem);

        ui->txtSubQuestion->clear();
        ui->lstQuestions->currentItem()->setExpanded(true);
        ui->txtSubQuestion->setFocus();
    }

    if (ui->lstQuestions->topLevelItemCount() > 0){
        ui->butEnter->setEnabled(true);
        ui->chkSubQuestion->setHidden(false);
    }

}




void frmMedicalForms::setUpMainWindow(){
    bool blDBConnection;
    QString strSQL, strDB;
    QSqlDatabase db;
    QStringList strHeaders;

    ui->grpForm->hide();
    ui->grpQuestions->hide();
    ui->txtSubQuestion->hide();
    ui->lblSubQuestion->hide();
    resizeWindow(200,140);
    ui->optForms->setFocus();
    strHeaders <<"Question"<<"Type";
    ui->lstQuestions->setHeaderLabels(strHeaders);




    strDB = "..\\database\\htcMedicalForms.sqlite";
    blDBConnection = ConnectToDB(strDB, db);

    QSqlQuery query;
    query.exec("SELECT Description FROM QuestionType");
    while (query.next())
    {
        ui->cmbType->addItem(query.value(0).toString());
    }

    db.close();


}


bool frmMedicalForms::ConnectToDB(QString strDB, QSqlDatabase &db)
{


    db = QSqlDatabase::addDatabase("QSQLITE");
    db.setDatabaseName(strDB);
    db.open();

    if(!db.isOpen())
    {
        QMessageBox::critical(0,"Cannot Connect to Database", qApp->tr("Cannot open database."));
        return false;
    }
    else
    {
           return true;
    }

}


void frmMedicalForms::on_butEnter_clicked()
{
    QString strSQL, strType;

    if (ui->optForms->isChecked() == true)
    {
        strType = "Form";
        if (ui->txtForm->text().length() >0)
        {
            strSQL = "INSERT INTO Form(Name) VALUES('" + ui->txtForm->text() + "')";
             UpdateDatabase(strSQL, strType);
        }
    }
    else if(ui->optQuestions->isChecked() == true)
    {
        if (ui->chkSubQuestion->isChecked() == true){
            ui->chkSubQuestion->setChecked(false);
        }

        strType = "Questions";
        updateDB_Questions();
    }

}


bool frmMedicalForms::UpdateDatabase(QString strSQL, QString strType)
{
    QSqlDatabase db;
    bool blSuccess;

    blSuccess = ConnectToDB("..\\database\\htcMedicalForms.sqlite", db);
    QSqlQuery query;
    blSuccess = query.exec(strSQL);
    if (blSuccess == true){
        QMessageBox::information(0,"Database - Success","The " + strType + " was successfully entered into the database.");
        ui->txtForm->setFocus();
        CleanUpForm();
    }
    else{
        QMessageBox::warning(0,"Database - Failure", "The " + strType + " was not entered into the database.");
    }
    return blSuccess;
}

void frmMedicalForms::CleanUpForm(){
    ui->txtForm->clear();
    ui->txtQuestion->clear();
    ui->cmbType->currentIndex() == 0;
    ui->cmbForm->currentIndex() - 1;
    ui->optForms->setFocus();
    ui->grpForm->hide();
    ui->grpQuestions->hide();
    if (ui->optForms->isChecked() == true){
        ui->optForms->setFocus();
    }
    else{
        ui->optQuestions->setFocus();
    }

}

QSqlQuery frmMedicalForms::QueryDB(QString strSQL){
    QSqlDatabase db;
    bool blSuccess;

    blSuccess = ConnectToDB("..\\database\\htcMedicalForms.sqlite", db);
    QSqlQuery query;
    query.exec(strSQL);
    return query;
}




void frmMedicalForms::updateDB_Questions(){
    QString strSQL, strItem, strType, strID;
    QTreeWidgetItem *objItem = new QTreeWidgetItem;;
    QTreeWidgetItem *objChild = new QTreeWidgetItem;;
    int intCount,intChildren, j, i;
    QSqlQuery query;


    strSQL = "Select ID from Form where Name = '" + ui->cmbForm->currentText() + "'";
    query = QueryDB(strSQL);
    while(query.next()){
        strID= query.value(0).toString();
    }
    query.finish();

    ui->lstQuestions->setCurrentItem(0);
    intCount = ui->lstQuestions->topLevelItemCount();
    for(j=0; j< intCount;j++){
        objItem = ui->lstQuestions->takeTopLevelItem(0);
        strItem = objItem->text(0);
        strType = objItem->text(1);

        strSQL = "Insert into Question (form_id, QuestionType_ID, Question)";
        strSQL = strSQL + " Select " + strID + ", ID, '" + strItem + "'";
        strSQL = strSQL + " from QuestionType";
        strSQL = strSQL + " where description = '" + strType + "'";

        query = QueryDB(strSQL);
        query.finish();

        intChildren = objItem->childCount();
        if (intChildren > 0){
            // getting ID of form you just entered
            strSQL = "select Question.ID";
            strSQL = strSQL + " from Question";
            strSQL = strSQL + " join QuestionType on Question.QuestionType_ID = QuestionType.ID";
            strSQL = strSQL + " Where Question.Form_ID = " + strID;
            strSQL = strSQL + " and Question.Question = '" + strItem + "'";

            query = QueryDB(strSQL);
            query.finish();

            while(query.next()){
                strID= query.value(0).toString();
            }
            for (i=0; i < intChildren; i++){
                objChild = objItem->takeChild(0);
                strItem = objChild->text(0);
                strType = objChild->text(1);

                strSQL = "Insert into SubQuestion (Type, Question, Question_ID)";
                strSQL = strSQL + " values ('" + strType + "','" + strItem + "','" + strID + "')";
                query = QueryDB(strSQL);

            }

      }
    }
}

void frmMedicalForms::Clean_grpQuestions(){

    if (ui->txtSubQuestion->text().length() > 0){
        ui->txtQuestion->selectAll();
        ui->txtSubQuestion->clear();
    }
    else{
        ui->txtQuestion->clear();
    }
    ui->txtQuestion->setFocus();
    ui->cmbType->currentIndex() == 0;



}


void frmMedicalForms::on_chkSubQuestion_clicked()
{
    if (ui->chkSubQuestion->isChecked() == true ){
        ui->txtQuestion->insert(ui->lstQuestions->currentItem()->text(0));
        ui->txtQuestion->setEnabled(false);


        ui->lblSubQuestion->show();
        ui->txtSubQuestion->show();
        ui->txtQuestion->setFocus();

    }
    else{
        ui->txtQuestion->setEnabled(true);
        ui->lblSubQuestion->hide();
        ui->txtSubQuestion->hide();
        ui->txtSubQuestion->clear();
        ui->lstQuestions->currentItem()->setExpanded(false);
        ui->txtQuestion->clear();
        ui->txtQuestion->setFocus();

    }
}

void frmMedicalForms::on_lstQuestions_doubleClicked(QModelIndex index)
{
    QTreeWidgetItem *currentItem = new QTreeWidgetItem;

    ui->lstQuestions->collapseAll();
    currentItem = ui->lstQuestions->currentItem();

    if (index.parent().isValid()== false){
        ui->txtQuestion->setEnabled(true);
        ui->txtQuestion->setText(currentItem->text(0));
        ui->chkSubQuestion->setChecked(false);
        if (currentItem->childCount()>0){
            ui->lstQuestions->expand(index);
        }
        // todo add combobox on double-click
    }




}
