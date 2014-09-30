<?php


    require_once('QueryDB.php');


    //Retrieving variables from $POST
    $Date = FixDate($_POST['svpDate']);
    $recordset = GetData($Date);
    $Path = CreateCSV($recordset);

    echo $Path;

    function GetData($Date)
    {
        $objDB = new QueryDB();

		if($objDB == false){
			$Status = 'Unable to Connect';
			return $Status;
		}
		else
        {
            $strSQL = "call ScheduleVsPunches('" . $Date . "')" ;
            return $recordset = $objDB->queryMySQL_Old($strSQL);

		}
    }

    function CreateCSV($Results)
    {
        $Report = 'ScheduleVsPunches' . time() . '.csv';
        $objFile = fopen("../Export/excel/" . $Report,"w");


        $j = 0;
        foreach($Results as $row)
        {
            if($j==0)
            {
                //adding headers
                fputcsv($objFile,array_keys($row));
            }

            //Adding Rows
            fputcsv($objFile,$row);
            $j++;
        }

        fclose($objFile);
        return $Report;
    }

    function FixDate($strDate)
    {
        $strDate = str_replace('/','-',$strDate);
        $arDate = split('-',$strDate);
        $strDate = $arDate[2] . '-' . $arDate[0] . '-' . $arDate[1];
        return $strDate;
    }
?>
