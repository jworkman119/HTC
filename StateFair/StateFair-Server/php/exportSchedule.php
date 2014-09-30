<?php
/**
 * Created by JetBrains PhpStorm.
 * User: patterj
 * Date: 7/8/13
 * Time: 3:13 PM
 * To change this template use File | Settings | File Templates.
 */
/*
    http://localhost/StateFair/php/downloadSchedule?XDEBUG_SESSION_START=default
 */
require_once './QueryDB.php';
/** Include PHPExcel */
require_once './PHPExcel/Classes/PHPExcel.php';

//$Zones=returnZones();
$StartDay = $_POST['StartDate'];
$StartDay = FixDate($StartDay);
$EndDay = $_POST['EndDate'];
$EndDay = FixDate($EndDay);

$SQL = "call DownloadSchedule('" . $StartDay . "','" . $EndDay . "')";
$recordset = returnRecordset($SQL);

$objPHPExcel = new PHPExcel();
$colDate='';
$Zone='';
$XLS = createWorkbook($recordset, $StartDay, $EndDay);
echo $XLS;

function returnRecordset($SQL){


    $objDB = new QueryDB();
    $recordset = $objDB->queryMySQL($SQL);

    return $recordset;
}

function createWorkbook($recordset, $StartDay, $EndDay)
{
    // Create new PHPExcel object

    global $objPHPExcel;
    $objPHPExcel->createSheet(1);
    $objPHPExcel->createSheet(2);

    $objPHPExcel->getDefaultStyle()->getFont()->setSize(7);

    // Set document properties
    $objPHPExcel->getProperties()->setCreator("HTC")
        ->setLastModifiedBy("HTC")
        ->setTitle("HTC - State Fair Schedule " . date("Y"))
        ->setSubject("State Fair Schedule " . date("Y"))
        ->setDescription("State Fair Schedule " . date("Y"));

    addHeaders($StartDay, $EndDay);
    addTimes($StartDay,$EndDay);
    // Add some data
    addWorksheetData($recordset);


    // adding data required for spreadsheet to work properly
    addStaticData();

    // Rename worksheet
    $objPHPExcel->setActiveSheetIndex(2)->setTitle('Overnight');
    $objPHPExcel->setActiveSheetIndex(1)->setTitle('Night');
    $objPHPExcel->setActiveSheetIndex(0)->setTitle('Morning');



    $objWriter = PHPExcel_IOFactory::createWriter($objPHPExcel, 'Excel5');

    $objWriter->save('../Export/excel/Schedule' . date("Y") . '.xls');

    return 'Schedule' . date("Y") . '.xls';

}

function returnTimes($StartDay,$EndDay)
{
    $SQL = "Select TimeIn, TimeOut,Max(Total) as Rows, Zone_ID,Description, Shift";
    $SQL = $SQL . " From vwSpreadsheetTimeCount";
    $SQL = $SQL . " Join Zone on Zone_ID = Zone.ID";
    $SQL = $SQL . " where Day >='" . $StartDay . "'";
    $SQL = $SQL . " and Day <='" . $EndDay . "'";
    $SQL = $SQL . " Group by Zone_ID, TimeIn,TimeOut, Shift ";
    $SQL = $SQL . " Order by Shift, Zone_ID, TimeIn, TimeOut";

    $Times = returnRecordset($SQL);
    return $Times;
}

function addTimes($StartDay, $EndDay)
{
    global $objPHPExcel;
    $Times = returnTimes($StartDay,$EndDay);
    $Worksheet=$objPHPExcel->setActiveSheetIndex(0);
    $Row=2;
    $Shift='Morning';
    $Sheet=0;
    $Zone='';
    foreach($Times as $Time)
    {
        if($Time['Shift'] != $Shift)
        {
            $Row=2;
            $Shift=$Time['Shift'];
            $Sheet++;
            $Worksheet = $objPHPExcel->setActiveSheetIndex($Sheet);
        }

        if($Zone != $Time['Zone_ID'])
        {
            $Worksheet->setCellValue('B'. $Row,$Time['Zone_ID']);
            $Worksheet->setCellValue('C' . $Row,$Time['Description']);
            BoldCell($Sheet,'B'.$Row,'false');
            $Zone=$Time['Zone_ID'];

        }

        $TimeString = createTimestring($Time['TimeIn'],$Time['TimeOut']);
        $Worksheet->setCellValue('A' . $Row,$TimeString);
        $Row = $Row + $Time['Rows'];
    }
}

function createTimeString($TimeIn,$TimeOut)
{
    $TimeIn = strtotime($TimeIn);
    $TimeIn = strftime('%l:%M',$TimeIn);
    $TimeOut = strtotime($TimeOut);
    $TimeOut = strftime('%l:%M %P',$TimeOut);

    return $TimeIn . ' - ' . $TimeOut;
}

function addWorksheetData($recordset)
{
    global $objPHPExcel,$Zone;

    $objPHPExcel->setActiveSheetIndex(0);
    $iRow = 2;
    $iSheet = 0;
    $Shift='';
    $rowTime='';
    $iCol=68;
    foreach($recordset as $row)
    {

        if($row['Shift']=='Morning')
        {
            $rowTime = addData($row,0,$iRow,$iCol,$rowTime);
        }
        elseif($row['Shift']=='Night')
        {

            $iRow=resetRow($Shift,$row['Shift'],$iRow);
            $rowTime = addData($row,1,$iRow,$iCol,$rowTime);
        }
        elseif($row['Shift']=='Overnight')
        {
            $iRow=resetRow($Shift,$row['Shift'],$iRow,$rowTime);
            $rowTime = addData($row,2,$iRow,$iCol,$rowTime);
        }
        $Shift=$row['Shift'];
        $iRow++;
    }

    // Resizing columns to fit contents in columns
    $Columns =$iCol - 65;
    autoFit($Columns);
}

/* Main Function that adds data to worksheet */
function addData($row, $sheet,&$iRow,&$iCol,$rowTime)
{
    global $objPHPExcel,$colDate, $Zone;

    $Date =  date_create($row['Day']);
    $Date = intval($Date->format('m')) . '/' . intval($Date->format('d'));

    while($Date!=$colDate and $iCol<700)
    {
        $colDate = $objPHPExcel->setActiveSheetIndex($sheet)->getCell(chr($iCol). 1);
        $colDate = $colDate->getValue();
        if($Date != $colDate)
        {
            $iCol++;
            $Zone='';
            $iRow=2;
        }
    }


        $foundRow='false';

        $Time = createTimeString($row['TimeIn'],$row['TimeOut']);
        while($foundRow=='false' and $iRow < 3000)
        {
            $ZoneCell=$objPHPExcel->setActiveSheetIndex($sheet)->getCell('B'.$iRow);

            if($ZoneCell != '' or $Zone=='')
            {
                $Zone=$ZoneCell->getValue();
            }

            $TimeCell=$objPHPExcel->setActiveSheetIndex($sheet)->getCell('A'.$iRow);

            if($TimeCell->getValue() !='')
            {
                $rowTime = $TimeCell->getValue();
            }

            $Cell=chr($iCol) . $iRow;
            if($Time == $rowTime && $Zone==$row['Zone_ID'])
            {
                $objPHPExcel->setActiveSheetIndex($sheet)->setCellValue( $Cell,$row['Person']);


                if($row['Role']=='supervisor')
                {
                    BoldCell($sheet,$Cell,'false');
                }
                $foundRow='true';
            }
            else
            {
                $iRow++;
            }
        }
    return $rowTime;
}

/* Need to reset the Row to 0, if we are on a new worksheet */
function resetRow($Old,$Current,$Row)
{
    if($Old != $Current)
    {
        $Row = 2;
        $Zone= '';
    }

    return $Row;
}

function addStaticData()
{
    global $objPHPExcel;

    // Redirect output to a client’s web browser (Excel5)
    header('Content-Type: application/vnd.ms-excel');
    header('Content-Disposition: attachment;filename="2013_Schedule.xls"');
    header('Cache-Control: max-age=0');
// If you're serving to IE 9, then the following may be needed
    header('Cache-Control: max-age=1');

// If you're serving to IE over SSL, then the following may be needed
    header ('Expires: Mon, 26 Jul 1997 05:00:00 GMT'); // Date in the past
    header ('Last-Modified: '.gmdate('D, d M Y H:i:s').' GMT'); // always modified
    header ('Cache-Control: cache, must-revalidate'); // HTTP/1.1
    header ('Pragma: public'); // HTTP/1.0

}

function autoFit($Columns)
{
    global $objPHPExcel;

    for($sheet=0;$sheet < 3;$sheet++)
    {
        for($j=0;$j<=$Columns;$j++)
        {
            $Col=chr($j+65);
            $objPHPExcel->setActiveSheetIndex($sheet)->getColumnDimension($Col)->setAutoSize(true);
        }
    }
}

function BoldCell($sheet,$cell,$underline)
{
    global $objPHPExcel;

    $objPHPExcel->setActiveSheetIndex($sheet)->getStyle($cell)->getFont()->setBold(true);
    if($underline=='true')
    {
        $objPHPExcel->setActiveSheetIndex($sheet)->getStyle($cell)->getFont()->setUnderline(true);
    }

}

function addHeaders($StartDay,$EndDay)
{
    global $objPHPExcel;
    $SQL = "Select Distinct Day from Schedule";
    $SQL = $SQL . " where Day >='" . $StartDay . "'";
    $SQL = $SQL . " and Day <='" . $EndDay . "'";
    $SQL = $SQL . " Order By Day";
    $recordset = returnRecordset($SQL);

    for($j=0;$j < 3;$j++)
    {
        $objPHPExcel->setActiveSheetIndex($j)->setCellValue('A1','Time');
        BoldCell($j,A1,'true');
        $objPHPExcel->setActiveSheetIndex($j)->setCellValue('B1','Zone');
        BoldCell($j,B1,'true');
        $objPHPExcel->setActiveSheetIndex($j)->setCellValue('C1','Zone Description');
        BoldCell($j,C1,'true');
        $Col=3;

        foreach($recordset as $row)
        {
            $Column=chr(65+$Col) . '1';
            $Date =  date_create($row['Day']);
            $Date = intval($Date->format('m')) . '/' . intval($Date->format('d'));
            $objPHPExcel->setActiveSheetIndex($j)->setCellValue($Column,$Date);
            BoldCell($j,$Column,'true');
            $Col++;
        }

    }

}

function returnZones()
{
    $SQL = "Select ID From Zone";
    $recordset = returnRecordset($SQL);

    return $recordset;
}

function FixDate($strDate)
{
    $strDate = str_replace('/','-',$strDate);
    $arDate = split('-',$strDate);
    $strDate = $arDate[2] . '-' . $arDate[0] . '-' . $arDate[1];
    return $strDate;
}

?>