<?php


    require_once('QueryDB.php');


    //Retrieving variables from $POST
    $Date = $_POST['Day'];
    $Day = FixDate($_POST['Day']);
    $Person = $_POST['Person'];

    CleanDirectory();
    $recordset = GetData($Day,$Person);
    $Success = CreateXML($recordset, $Day, $Shift);
    createHTML();
/*
    $Worked = chmod("../Export/pdf/RosterSheets.pdf",0777);
    $Worked = chmod("../Export/pdf/RosterSheets.html",0777);
    $Worked = chmod("../Export/pdf/RosterSheets.xml",0777);
*/

    $pdf = createPDF();
    echo $pdf;

    function CleanDirectory()
    {
        $output = shell_exec('../Export/pdf/deletePDF.sh');
    }

    function GetData($Day,$Supervisor)
    {
        $objDB = new QueryDB();

		if($objDB == false){
			$Status = 'Unable to Connect';
			return $Status;
		}
		else
        {
            $strSQL = "call ReturnRosterSheets('" . $Day . "','" . $Supervisor . "')" ;
            return $recordset = $objDB->queryMySQL($strSQL);

		}
    }


    function CreateXML($Results, $Date)
    {
        $writer = new XMLWriter();
        
        $writer->openUri('../Export/pdf/RosterSheets.xml');
        $writer->startDocument();
        $writer->startElement('Roster');
            $Element = $Results[0];
            $writer->writeElement('Day', $Element[Day]);
            $writer->writeElement('Shift',$Element[SupShift]);
            $j = 0;
            $Supervisor = '';
            foreach($Results as $row)
            {
                if ($Supervisor != $row['Supervisor'])
                {
                    $Supervisor = $row['Supervisor'];
                    if($j!=0)
                    {
                        //need to end previous Group Element.
                        $writer->endElement();
                    }
                    $j++;
                    $writer->startElement('Group');
                    $writer->startElement('Supervisor');
                        $writer->writeAttribute('Name', $row['Supervisor']);
                        $writer->writeAttribute('Zone', $row['SupZone']);
                        $writer->writeAttribute('Shift', $row['SupShift']);
                    $writer->endElement();
                }

                $writer->startElement('Worker');
                    $writer->writeAttribute('Name',$row['Worker']);
                    $writer->writeAttribute('Shift',$row['Shift']);
                    $writer->writeAttribute('PicPath',$row['PicPath']);
                    $writer->writeAttribute('Zone',$row['Zone']);
                $writer->endElement();
            }

        $writer->endElement();
        $writer->endDocument();
        $writer->flush();
    }



    function createHTML()
    {
        $dom= new DOMDocument();
        if ($dom->load('../Export/pdf/RosterSheets.xml') == false) // loadXML will fail
            die('Failed to load source XML: ');

        $xsl = new DOMDocument();
        $path = '../Export/pdf/RosterSheets.xsl';

        if ($xsl->load($path) == false) // loadXML will fail
            die('Failed to load source XSL: '); 

        $xslProcess = new XSLTProcessor();
        $xslProcess->importStylesheet($xsl);

        $xslProcess->transformToUri($dom, '../Export/pdf/RosterSheets.html');
   
    }


    function createPDF()
    {
        $pdf = 'RosterSheets' . time() .'.pdf';
        $pdfPath = '/srv/http/StateFair/Export/pdf/' . $pdf;
//        $output = shell_exec('/srv/http/StateFair/Export/pdf/./wkhtmltopdf /srv/http/StateFair/Export/pdf/RosterSheets.html ' . $pdfPath);
        $output = shell_exec('wkhtmltopdf /srv/http/StateFair/Export/pdf/RosterSheets.html ' . $pdfPath);
        return $pdf;
    }

    function FixDate($strDate)
    {
        $strDate = str_replace('/','-',$strDate);
        $arDate = split('-',$strDate);
        $strDate = $arDate[2] . '-' . $arDate[0] . '-' . $arDate[1];
        return $strDate;
    }
?>
