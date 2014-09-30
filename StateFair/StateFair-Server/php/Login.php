
<?php
    require_once('QueryDB.php');
    $SQL = $_POST['SQL'];
    $Type = $_POST['Type'];


    $objLogin = new Login();
    $return = $objLogin->CheckLogin($SQL,$Type);
    if ($objLogin->Error != null)
    {
        $return = "Error - " . $objLogin->Error;
    }

//    $return = 'Test';
    echo $return;

    Class Login
    {
        public $Error=null;

        public function CheckLogin($SQL,$Type)
        {
                $return="";
                if($Type=='return')
                {
                    $recordset = $this->returnLogin($SQL);
                    $recordset = json_encode($recordset);
                    $return =  $recordset;
                }
                else
                {
                    $Pass = $this->updatePwd($SQL);
                    $return = $Pass;
                }

                return $return;
        }

        private function updatePwd($strSQL)
        {
            $objDB = new QueryDB();
            $Pass =  $objDB->queryMySQL_Scalar($strSQL);
            return $Pass;
        }

        private function returnLogin($strSQL)
        {

            $objDB = new QueryDB();
            $recordset = $objDB->queryMySQL($strSQL);
            if($objDB->Error != null)
            {
                $Error = $objDB->Error;
            }
            return $recordset;
        }




    }
?>