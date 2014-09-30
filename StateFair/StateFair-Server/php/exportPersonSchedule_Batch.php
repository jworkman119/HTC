<?php
/**
 * Created by PhpStorm.
 * User: patterj
 * Date: 7/31/14
 * Time: 12:12 PM
 */
require_once('QueryDB.php');

CleanDirectory();
$Recordset = GetData($WorkerID);
createXML($Recordset);
createHTML();

$pdfPath = createPDF();
echo $pdfPath;


function CleanDirectory()
{
    $output = shell_exec('../Export/pdf/deletePDF.sh');
}

function GetData($WorkerID)
{
    $objDB = new QueryDB();

    if($objDB == false){
        $Status = 'Unable to Connect';
        return $Status;
    }
    else
    {
        $strSQL = "call returnSchedule_Batch()" ;
        return $recordset = $objDB->queryMySQL($strSQL);

    }
}

function createXML($recordset)
{

    $writer = new XMLWriter();

    $writer->openUri('../Export/pdf/Schedule.xml');
    $writer->startDocument();
    $writer->startElement('Schedule');

    $j = 0;
    $Person="";
    foreach($recordset as $row)
    {
        if($Person=="" || $Person != $row['Person'])
        {

            if($Person!="")
            {
                $writer->endElement();
            }

            $Person=$row['Person'];
            $writer->startElement('Person');
                $writer->writeElement('Name',$Person);

        }

        $writer->startElement('Day');
            $writer->writeAttribute('Date',$row['Day']);
            $writer->writeElement('TimeIn', $row['TimeIn']);
            $writer->writeElement('TimeOut', $row['TimeOut']);
            $writer->writeElement('Zone', $row['Zone']);
        $writer->endElement();
        $j++;

    }

        $writer->endElement();
        $writer->endDocument();
        $writer->flush();

}

function createHTML()
{
    $dom= new DOMDocument();
    if ($dom->load('../Export/pdf/Schedule.xml') == false) // loadXML will fail
        die('Failed to load source XML: ');

    $xsl = new DOMDocument();
    $path = '../Export/pdf/Schedule_Batch.xsl';

    if ($xsl->load($path) == false) // loadXML will fail
        die('Failed to load source XSL: ');

    $xslProcess = new XSLTProcessor();
    $xslProcess->importStylesheet($xsl);

    $xslProcess->transformToUri($dom, '../Export/pdf/Schedule.html');
}

function createPDF()
{
//    $pdf = 'Schedule' . time() .'.pdf';
    $pdf= 'Schedule.pdf';
    $pdfPath = '/srv/http/StateFair/Export/pdf/' . $pdf;
 //   $output = shell_exec('/srv/http/StateFair/Export/pdf/./wkhtmltopdf /srv/http/StateFair/Export/pdf/Schedule.html ' . $pdfPath);
    $output = shell_exec('wkhtmltopdf /srv/http/StateFair/Export/pdf/Schedule.html ' . $pdfPath);
    return $pdf;
}

    ?>