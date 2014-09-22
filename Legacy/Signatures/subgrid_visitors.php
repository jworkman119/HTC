<?php
	require_once('clsWorkWithDB.php');
	
	// get the id passed automatically to the request
	$id = $_GET['id'];
	$getID = $_GET['VisitorID'];
	
	$strSQL = "Select Location.Description, strftime('%m/%d/%Y %H:%M', timestamp, 'localtime')";
	$strSQL = $strSQL . ' From Signature';
	$strSQL = $strSQL . ' Left Join Location on Signature.Location_Id = Location.Id';
	
	$Data = Get_Data($strSQL);
	echo $Data;


?>