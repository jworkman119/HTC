<?php
require_once('QueryDB.php');
$SQL = $_POST['SQL'];
$Result = $_POST['Result'];

    if(strPos($SQL,'Time_Manually(') >0)
    {
        $SQL = checkTimes($SQL);
    }

    $recordset = returnData($SQL, $Result);

    echo $recordset;


function returnData($strSQL, $Result)
{

    $objDB = new QueryDB();
    $recordset = $objDB->queryMySQL($strSQL);

    if($Result == "Result")
    {
        $recordset = json_encode($recordset);
    }
    return $recordset;
}

/* Need to check times so a time that runs into next working day will be recorded in the database properly. ex: 4pm - 12am */
function checkTimes($SQL)
{
    $ProcName = substr($SQL,0,strPos($SQL,'('));
    $Dates = substr($SQL,strpos($SQL,'(') + 1, strpos($SQL,')') - (strpos($SQL,'(') + 1));
    $arDates = split(',',$Dates);

    $TimeIn =  change2PhpDate($arDates[1]);
    $TimeOut = change2PhpDate($arDates[2]);
    $difference=date_diff($TimeIn,$TimeOut);
    if($difference->invert==1)
    {
        $TimeOut = date_add($TimeOut,date_interval_create_from_date_string("1 day"));
        $SQL = rebuildSQL($ProcName,$arDates[0],$TimeIn,$TimeOut);
    }

    return $SQL;
}

function change2PhpDate($Time)
{
    $Time = substr($Time,1,strlen($Time) -2);
    $Time = date_create($Time);

    return $Time;
}

function rebuildSQL($ProcName,$ID, $TimeIn,$TimeOut)
{
    $TimeIn = $TimeIn->format('Y-m-d H:i');
    $TimeOut = $TimeOut->format('Y-m-d H:i');
    $SQL = $ProcName . '(' . $ID . ",'" . $TimeIn . "','" .$TimeOut . "')";

    return $SQL;
}

?>