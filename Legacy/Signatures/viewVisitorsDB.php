<?php

/*
?XDEBUG_SESSION_START=session_name
*/

	require_once('clsWorkWithDB.php');

	$strSQL = $strSQL . ' Select Visitor.Company'; 
	$strSQL = $strSQL . ', Visitor.LastName ||   \',  \' || Visitor.FirstName as Visitor';
	$strSQL = $strSQL . ', Visitor.ID as VisitorID';
	$strSQL = $strSQL . ',  Location.Description as Location';
	$strSQL = $strSQL . ', strftime( \'%m/%d/%Y %H:%M\', timestamp, \'localtime\') as Date';
	$strSQL = $strSQL . ', Signature.ID as VisitID';
	$strSQL = $strSQL . ' From Visitor';
	$strSQL = $strSQL . ' join Signature on Visitor.ID = Signature.Visitor_ID';
	$strSQL = $strSQL . ' Left Join Location on Signature.Location_Id = Location.Id';
	$strSQL = $strSQL . ' Order by Company desc, Visitor.LastName desc, Date;';


	$Data = Get_Data($strSQL);
	echo $Data;
	

	function Get_Data($strSQL)
	{
		$DB = 'sqlite:./Database/DocumentSignatures2.sqlite';	
		$objDB = new clsWorkWithDB($DB);
		
		$Results = $objDB->QueryDB($strSQL,'Select');
		$strReturn = '"Total":"1"';
		$strReturn = $strReturn . ',"page":"1"';
		$strReturn = $strReturn . ',"recordcount":"' . (string)$objDB->RecordCount . '"';
		
		$Data = Get_Rows2($objDB->Recordset, $objDB->ColumnCount);
		$strReturn = '{' . $strReturn . ',"rows":[' . $Data . ']}';
		
		return $strReturn;
	}
	
	function Get_Rows2($Rows, $Cols)
	{

		$Count = 1;
		$SkipCompany = null;
		$SkipVisitor = null;
		$spot = 1;
		$ReturnData = array();
		foreach($Rows as $row){
			for($j=0;$j<$Cols;$j++){
				
				if($j==0 && $SkipCompany != $row['Company'])	//	handle Company - 1st level of tree 
				{ 
					$root = $spot; // going to pass to visitor->parent	
					$cell = Get_ColumnData($spot,'Company', $row['Company']);
					$Data = '{ "id":'. (string)$spot . ',"cell":' . $cell . '}';
					$SkipCompany = $row['Company'];
					updateValues($spot,$ReturnData,$Data);
				}
				elseif($j==1 && $SkipVisitor != $row['Visitor'])	// handle Visitor - 2nd level of tree
				{ 
					
					$cell = Get_ColumnData($spot,'Visitor', $row['Visitor'],$row['VisitorID'], $root);
					$Data = '{ "id":'. (string)$spot . ',"cell":' . $cell . '}'; 
					$SkipVisitor = $row['Visitor'];
					$root = $spot; // going to pass to visitor->parent
					updateValues($spot,$ReturnData,$Data);


				}
				elseif ($j==3){ // handle Visits - 3rd level of tree
					$cell = Get_ColumnData($spot,'Date', $row['Date'],$row['Location'], $root, $row['VisitID']);
					$Data = '{ "id":'. (string)$spot . ',"cell":' . $cell . '}'; 
					updateValues($spot,$ReturnData,$Data);
				}

			}
			++$Count;
		}
		
		$strReturn = implode(',',$ReturnData);
		Return $strReturn;
	
	}
	
	function updateValues(&$spot,&$rows, $Data)
	{
		$spot= $spot+1;
		$rows[]=$Data;
	}

	function Get_ColumnData($id,$Type,$value,$value2=null,$root=null, $visitID=null)
	{
		$Data = array('id'=>$id,'company'=>null,'visitor'=>null,'visitorID'=>null,'Date'=>null,'Location'=>null,'VisitID'=>null,'level'=>null,'parent'=>$root,'leaf'=>null,'expandable'=>null);
			
			if ($Type == 'Company'){
				$Data['company']= '"' . $value . '"';
				$Data['visitor']='""';
				$Data['level']=0;
				$Data['parent']='null';
				$Data['leaf']='false';
				$Data['expandable']='false';
				$Data['visitorID']='null';
				$Data['Date']='null';
				$Data['Location']='null';
				$Data['VisitID']='null';
				
			}
			else if ($Type == 'Visitor'){
				$Data['company']='""';
				$Data['visitor']= '"' . $value . '"';
				$Data['level']=1;
				$Data['parent']=$root;
				$Data['leaf']='false';
				$Data['expandable']='false';
				$Data['visitorID']=$value2;
				$Data['Date']='null';
				$Data['Location']='null';
				$Data['VisitID']='null';
			}
			else{
				$Data['company']='""';
				$Data['visitor']= 'null';
				$Data['level']=2;
				$Data['parent']=$root;
				$Data['leaf']='true';
				$Data['expandable']='true';
				$Data['visitorID']='null';
				$Data['Date']='"' . $value . '"';
				$Data['Location']='"' . $value2 . '"';
				$Data['VisitID']=$visitID;
			}

			$Row = array_values($Data);
			$Row = '[' . implode(',',$Row) . ']';
			Return $Row;
	}

	/*
	function Get_Rows($Rows, $ColumnCount)
	{
	
		$Count = 1;
		foreach($Rows as $row){
		//Holding onto for later reference
			if($Count == 1){
				$Headers=array_keys($row);
			}
			$cells = json_encode($row);
			//adding row id, required for grid	
			$cells = str_replace('{', '{"id":"' . (string)$Count . '",', $cells);
			$Data = $Data .  $cells;
		
			++$Count;
		}
		$Data = str_replace('}{','},{',$Data);
		return '[' . $Data . ']';
	
	}
*/
	
?>