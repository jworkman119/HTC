<?php

/*
?XDEBUG_SESSION_START=session_name
*/

	require_once('clsWorkWithDB.php');
	
	// Retrieving variables from Post
	$Img = $_POST['Img'];
	$First = $_POST['First'];
	$Last = $_POST['Last'];
	$Badge = $_POST['Badge'];
	$Company = $_POST['Company'];
	$Document = $_POST['Document'];

	$strSQL = Create_SQL($Img, $First, $Last, $Badge, $Company, $Document);

	$DB = 'sqlite:./Database/DocumentSignatures2.sqlite';	
	$objDB = new clsWorkWithDB($DB);
	
	$strStatus = $objDB->QueryDB($strSQL);
	// add error checking on results.
	if ($objDB->Success == true){
		echo $objDB->Description;
	}
	else{
		echo 'Error: ' . $objDB->Description;
	}

/**************************** - Methods - *********************************/	
    function Create_SQL($sImg, $sFirst, $sLast, $iBadge, $sCompany, $sDocument)
    {
		$sImg = '\''  . $sImg . '\'';
	
		$strSQL = 'Insert Into Signature(Visitor_ID,Badge_No, Signature, Document_ID)';
        $strSQL = $strSQL . ' Select Visitor.ID,'  . (string)$iBadge . ',' . $sImg;
		$strSQL = $strSQL . ' ,(Select Document.ID From Document Where Document.FileName=\'' . $sDocument . '\')';
		$strSQL = $strSQL . ' From Visitor';
		$strSQL = $strSQL . ' Where Visitor.FirstName =\'' . $sFirst . '\'';
		$strSQL = $strSQL . ' And Visitor.LastName = \'' . $sLast . '\'';
		$strSQL = $strSQL . ' And Visitor.Company = \'' . $sCompany . '\'';

		$intLength = strlen($strSQL);
        return $strSQL;
  
  }

?>

   