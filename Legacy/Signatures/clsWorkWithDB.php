<?php

	class clsWorkWithDB{
		
	
		/***** - Properties - *****/
			//Type of query - used for return message
			public $Type;
			public $RecordCount;
			public $Recordset;
			public $ColumnCount;
			// used for error checking
			public $Success;
			public $Description;
		
			private $DBPath;
			
		/***** - Methods - *****/

		function __construct($path)
		{
			$this->DBPath = $path;
		}

		private function setRecordCount($Rows)
		{
			$Count = 0;
			foreach($Rows as $row){
				$Count = ++$Count;
				
			}
		
			$this->RecordCount = $Count;
		}
		
		public function QueryDB($strSQL,$queryType='NoSelect')
		{
		    try{
				$DB = new PDO($this->DBPath);
				if($DB == false){
					$this->Description = 'Unable to Connect';
					$this->Success = false;
				}
				elseif($queryType == 'Select'){
					$Results = $DB->query($strSQL);
					$this->Success = true;
					$this->Recordset = $Results->fetchAll(PDO::FETCH_ASSOC);
					$this->ColumnCount = $Results->columnCount();
					$this->RecordCount = count($this->Recordset);
					
					$this->Description = 'Rows returned from DB: ' . (string)$this->Recordcount;
				}
				else {
					$Results = $DB->query($strSQL);
					$this->Success = true;
					
					$this->Description = 'Data was successfully added to the database';
				}
				
			}
			catch(Exception $e){
				$this->Description = 'Function clsWorkWithDB.returnQuery failed: ' . $e->getMessage();
				$this->Success = false;
			}

			return $Results;
		}
		
	}

?>