<?php
/**
 * Created by PhpStorm.
 * User: patterj
 * Date: 6/3/14
 * Time: 9:59 AM
 */
require_once('QueryDB.php');

$recordset = GetData();
CreateXML($recordset);

function GetData()
{
    $objDB = new QueryDB();

    if($objDB == false){
        $Status = 'Unable to Connect';
        return $Status;
    }
    else
    {
        $strSQL = "Select ID, concat(FirstName,' ' , LastName)  as Worker  From Person" ;
        return $recordset = $objDB->queryMySQL($strSQL);

    }
}

function CreateXML($Results)
{
    $writer = new XMLWriter();

    $writer->openUri('../xml/Workers.xml');
    $writer->startDocument();
    $writer->startElement('Workers');
    $Element = $Results[0];

    $j = 0;
    $Supervisor = '';
    foreach($Results as $row)
    {
        $writer->startElement('Worker');
        $writer->writeElement('ID',$row['ID']);
        $writer->writeElement('FullName',$row['Worker']);
        $writer->endElement();
    }

    $writer->endElement();
    $writer->endDocument();
    $writer->flush();
}