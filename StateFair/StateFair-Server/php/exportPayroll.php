<?php


    require_once('QueryDB.php');


    //Retrieving variables from $POST
    $From = FixDate($_POST['FromDate']);
    $To = FixDate($_POST['ToDate']);
    $recordset = GetData($From,$To);
    $Path = CreateCSV($recordset);

    echo $Path;

    function GetData($From,$To)
    {
        $objDB = new QueryDB();

		if($objDB == false){
			$Status = 'Unable to Connect';
			return $Status;
		}
		else
        {
            $strSQL = "call DailyPayroll('" . $From . "','" . $To . "')" ;
            return $recordset = $objDB->queryMySQL_Old($strSQL);

		}
    }

    function CreateCSV($Results)
    {
        $Report = 'DailyPayroll' . time() . '.csv';
        if (file_exists("../Export/excel/".$Report))
        {
            $Worked = chmod("../Export/excel/DailyPayroll.csv",0777);
            shell_exec('./deleteCSV');

        }

        $objFile = fopen("../Export/excel/" . $Report,"w");


        //Adding Headers


        //Adding Rows
        $j = 0;
        foreach($Results as $row)
        {
            if($j==0)
            {
                fputcsv($objFile,array_keys($row));
            }

            fputcsv($objFile,$row);
            $j++;
        }

        fclose($objFile);
        return $Report;
    }

    function CreateXML($Results)
    {
        $writer = new XMLWriter();
        $writer->openUri('../Export/excel/DailyPayroll.xml');
        $writer->startDocument();
        $writer->startElement('Payroll');

            foreach($Results as $row)
            {
                $writer->startElement('row');
                    $writer->writeElement('ID',$row['ID']);
                    $writer->writeElement('Worker',$row['Worker']);
                    $writer->writeElement('Role',$row['Role']);
                    $writer->writeElement('Day',$row['Day']);
                    $writer->writeElement('Time In',$row['Time_In']);
                    $writer->writeElement('Time Out',$row['Time_Out']);
                    $writer->writeElement('Time Worked',$row['Time_Worked']);
                    $writer->writeElement('Garbage',$row['Garbage']);
                    $writer->writeElement('Bathroom',$row['Bathroom']);
                    $writer->writeElement('Type',$row['Type']);
                $writer->endElement();
            }

        $writer->endElement();
        $writer->endDocument();
        $writer->flush();
    }



    function createHTML($Document)
    {
        $dom= new DOMDocument();
        if ($dom->load('../pdf/document.xml') == false) // loadXML will fail
            die('Failed to load source XML: ');

        $xsl = new DOMDocument();

        if ($Document == 'Sign In'){
            $path = '../pdf/SignIn.xsl';
        }
        else{
            $path = '../pdf/VisitorConfidentiality.xsl';
        }

         if ($xsl->load($path) == false) // loadXML will fail
            die('Failed to load source XSL: '); 

        $xslProcess = new XSLTProcessor();
        $xslProcess->importStylesheet($xsl);

        $xslProcess->transformToUri($dom, '../pdf/document.html');
   
        
    }

    function FixDate($strDate)
    {
        $strDate = str_replace('/','-',$strDate);
        $arDate = split('-',$strDate);
        $strDate = $arDate[2] . '-' . $arDate[0] . '-' . $arDate[1];
        return $strDate;
    }
?>
