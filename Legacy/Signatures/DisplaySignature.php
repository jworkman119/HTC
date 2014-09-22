<?php
	require_once './php/signature-to-image.php';

	$img = returnImage();

	// Output to browser
	header('Content-Type: image/png');
	//imagepng($img);
	imagepng($img,'Test_Sig.png');
	// Destroy the image in memory when complete
	imagedestroy($img);
			
	function returnImage(){
		$results = queryDB();

		foreach($results as $row)
        {
			if (is_string($results) == true){
				die($row);
			}
			else{
				$img = sigJsonToImage($row['Signature']);
			}
		}
				
		Return $img;
	}
	
	function queryDB(){

		$DB = new PDO('sqlite:./DataBase/DocumentSignatures2.sqlite');

		$strSQL = "Select Signature from Signature Order by Timestamp desc Limit 1";
		if($DB == false){
			$Status = 'Unable to Connect';
			return $Status;
		}
		else {
			$query = $DB->prepare($strSQL);
			$query->execute();
			$results = $query->fetchAll();
			return $results;
		}
	}
		
?>
