<?php

	require_once('clsWorkWithDB.php');
	
	$First = $_POST['First'];
	$Last = $_POST['Last'];
	$Company = $_POST['Company'];
	$Badge = $_POST['Badge'];
	
	$SQL = initialSQL($First,$Last,$Company);

	$DB = 'sqlite:./Database/DocumentSignatures2.sqlite';	
	$objDB = new clsWorkWithDB($DB);

	$Results = $objDB->QueryDB($SQL);

	if ($objDB->Success == true){
		$Document = findDocument($Results, $objDB);
	}
	
	if ($objDB->Success == true){
		echo $Document;
	}
	else
	{
		echo 'Error: ' . $objDB->Description;
	}

	function initialSQL($First, $Last, $Company)
    {
		for($j=0;$j<2;$j++){
			if($j==0){
				$strSQL = "Select count(*)";
			}
			else{
				$strSQL = 'Select (' . $strSQL .') as Rows, *';
			}
			$strSQL = $strSQL . " FROM Visitor";
			$strSQL = $strSQL . " WHERE FirstName='" . $First . "'";
			$strSQL = $strSQL . " AND LastName='" . $Last . "'";
			$strSQL = $strSQL . " AND Company='" . $Company . "'";
		}
        return $strSQL . ';';
    }

	function addVisitorSQL($First, $Last, $Company)
    {

			$strSQL = 'Insert Into Visitor(FirstName,LastName,Company)';
			$strSQL = $strSQL . " Values('" . $First . "', '" . $Last . "', '" . $Company . "')";

			return $strSQL . ';';
    }
	
    
	function findDocument($Results, $objDB){
		$Count = $Results->fetchColumn(0);
			
		if ($Count == 0){
			// user has never signed in to HTC
			$strSQL = addVisitorSQL($GLOBALS['First'],$GLOBALS['Last'],$GLOBALS['Company']);
			
			// enter user into DocumentSignatures2..Visitor table
			$Results = $objDB->QueryDB($strSQL);

			$Document = 'VisitorConfidentiality.php';
		}
		else if ($Count == 1){
			// user has signed in before.
			$Document = 'SignIn.php';
		}
		else{
			// Code not implemented yet
			$Document = json_encode($Results->fetchAll(PDO::FETCH_ASSOC));
		}
		
		return $Document;
	}
	
?>