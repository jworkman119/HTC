<?php
/**
http://localhost/StateFair/ImportSchedule.html?XDEBUG_SESSION_START=default

 * Created by JetBrains PhpStorm.
 * User: patterj
 * Date: 7/25/13
 * Time: 10:40 AM
 * To change this template use File | Settings | File Templates.
 */

/** Include PHPExcel */
require_once './PHPExcel/Classes/PHPExcel.php';
require_once 'QueryDB.php';

if( empty($_FILES) == false)
{
    $Pass = uploadSchedule($_FILES);
}
else
{
    $StartDay = $_POST['StartDate'];
    $ColStart = substr($StartDay,  0,strlen($StartDay) - 5);
    $StartDay = FixDate($StartDay);

    $EndDay = $_POST['EndDate'];
    $ColEnd = substr($EndDay,  0,strlen($EndDay) - 5);
    $EndDay = FixDate($EndDay);

    $Fails= parseSchedule($StartDay,$ColStart, $EndDay, $ColEnd);
    if(sizeof($Fails)==0)
        $Return = 'Success';
    else
    {
        $Return = json_encode($Fails);
    }
    echo  $Return;
}

function uploadSchedule($Files)
{
    $File = $Files['files']['name'];
    $tmp_name = $Files['files']["tmp_name"];
    $temp=$tmp_name[0];
    $blMoved =  move_uploaded_file($temp, '../Import/Schedule_2014.xls');
    if ($blMoved>0)
        $Success =  "Uploaded";
    else
        $Success = "Fail";

    return $Success;
}

function parseSchedule($StartDay,$ColStart, $EndDay, $ColEnd)
{

    $inputFileName = '../Import/Schedule_2014.xls';

    /** Create a new Excel5 Reader  **/
    $objReader = new PHPExcel_Reader_Excel5();

    /** Load $inputFileName to a PHPExcel Object  **/

    $objPHPExcel = $objReader->load($inputFileName);
    $intSheets = $objPHPExcel->getSheetCount();
    $Fails=array();
    for($j=0;$j<$intSheets;$j++)
    {
        $objPHPExcel->setActiveSheetIndex($j);
        $Sheet = $objPHPExcel->getActiveSheet();
        // Finding the right Column - start at fourth column
         $Asc=68;
         for($Asc=68;$Asc<85;$Asc++)
         {
             $Pass = findColumn($Sheet,$Asc,$StartDay,$EndDay);
             if ($Pass=='true')
             {
                $Cell=$Sheet->getCell(chr($Asc) . 1);
                $Day = $Cell->getValue();
                $Day = FixDate($Day . '/' . date("Y"));
                 enterData($Asc,$Sheet,$Day,$Fails) ;
             }
             elseif($Pass=='done')
                 break;
         }
    }
    return $Fails;
}

function enterData($Col,$Sheet,$Day, &$Fails)
{
    $SheetName = $Sheet->getTitle();
    $objDB = new QueryDB();

    deleteData($objDB,$SheetName,$Day);

    for($j=2;$j<500;$j++)
    {
            $Time_Holder = getCellValue(65,$j,$Sheet);
            if($Time_Holder != '')
            {
                $Time = $Time_Holder;
                $Times = getTimes($Time,$SheetName);

            }


            $Zone_Holder = getCellValue(66,$j,$Sheet);
            if($Zone_Holder != '')
                $Zone = $Zone_Holder;

            $Person=getCellValue($Col,$j,$Sheet);
            if(trim($Person) !='')
            {
                $Person = str_replace("'","''",$Person); // removing all occurances
                $SQL = "call addSchedule_Auto (" . "'" . $Person . "','" . $Zone  . "','" .  $Day . "','" . $Times[0] . "','" . $Times[1] . "')";
                $Pass = $objDB->queryMySQL_Scalar($SQL);
                if($Pass=='Fail')
                {

                    $Fail = array('Person'=>$Person, 'Zone'=>$Zone, 'Day'=>date_format(date_create($Day),'m/d/Y') , 'Time'=>$Time );
                    $Fails[] = $Fail;
                }
            }
    }
}

function deleteData($objDB, $SheetName, $Day)
{
    $SQL = "call deleteSchedule_Auto(" . "'" .  $Day . "','" . $SheetName . "')";
    $Pass = $objDB->queryMySQL_Scalar($SQL);
}

function getCellValue($Col,$Row,$Sheet)
{
    $Coordinate = chr($Col) . $Row;
    $Cell = $Sheet->getCell($Coordinate);
    $Val = $Cell->getValue();

    return $Val;
}

function FixDate($strDate)
{
    $strDate = str_replace('/','-',$strDate);
    $arDate = split('-',$strDate);
    $strDate = $arDate[2] . '-' . $arDate[0] . '-' . $arDate[1];
    return $strDate;
}

function findColumn($Sheet, $Col, $StartDay, $EndDay)
{
    $Coordinate = chr($Col) . '1';
   $Cell = $Sheet->getCell($Coordinate);
    $Val = $Cell->getValue();
    $Pass = verifyDate($StartDay,$EndDay,$Val);

    return $Pass;

}

function verifyDate($StartDay, $EndDay, $ColDate)
{
    $StartDay = strtotime($StartDay);
    $EndDay = strtotime($EndDay);
    $Year = date('Y');
    $ColDate = FixDate($ColDate . '/' . $Year);
    $ColDate = strtotime($ColDate);
    if($ColDate >= $StartDay and $ColDate<=$EndDay)
        $Pass = 'true';
    elseif($ColDate>$EndDay)
        $Pass = 'done';
    else
        $Pass = 'false';

    return $Pass;

}

function getTimes($Time,$SheetName)
{
    $Times = split("-",$Time);
    $Times[0]=trim($Times[0]);
    $Times[1]=trim($Times[1]);

    //setting Start Time am or PM
    if($SheetName=='Morning')
    {
        $Times[0]=$Times[0] . ' am';
    }
    elseif($SheetName=='Night')
    {
        $Times[0]=$Times[0] . ' pm';
    }
    elseif($SheetName == 'Overnight')
    {
        if($Times[0]=='12:00')
            $Times[0] = $Times[0] . ' am';
        else
        {
            $AM = strtotime($Times[0] . ' am');
            $PM = strtotime($Times[0] . ' pm');
            $EndTime = strtotime($Times[1]);

            $amDiff = gmdate("H",$EndTime - $AM);
            $pmDiff = gmdate("H",$EndTime - $PM);

            if($pmDiff<14)
                $Times[0] = $Times[0] . ' pm';
            else
                $Times[0] = $Times[0] . ' am';
        }
    }
    $Times[0] =  date("H:i", strtotime($Times[0]));
    $Times[1] = date("H:i", strtotime($Times[1]));
    return $Times;
}



?>