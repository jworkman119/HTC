<?php
    /* QueryDB.php?XDEBUG_SESSION_START=default */
    class QueryDB
    {
        /*********** - properties - ************/
        public $Error;
        public $Recordcount;

        /*********** - functions - ************/

        public function queryMySQL_Old($strSQL)
        {

            $link = mysql_connect('162.209.63.14:3306','rootHTC','dwyeR2260'); //50.57.85.220
            if (!$link)
            {
                $Error = 'Could not connect: ' . mysql_error();
            }
            else
            {
                mysql_select_db('htcStateFair');
                $result = mysql_query($strSQL);

                $rows = mysql_num_rows($result);
                for($j=0; $j<$rows;$j++)
                {
                    $recordset[] = mysql_fetch_array($result,MYSQL_ASSOC);
                }
                $Recordcount = $j;

                mysql_close($link);
                return $recordset;
            }

        }

        public function queryMySQL($strSQL)
        {
            $dbLink = new PDO("mysql:host=162.209.63.14:3306;dbname=htcStateFair", 'rootHTC','dwyeR2260');
            if(!$dbLink)
            {
                $this->Error = 'Could not connect: ' . mysql_error();
            }
            else
            {
                $result = $dbLink->query($strSQL);
                $rows = $result->rowCount();
                for($j=0; $j<$rows;$j++)
                {
                    $recordset[] = $result->fetch();
                }

                return $recordset;
            }

        }


        public function queryMySQL_Scalar($strSQL)
        {

            $link = mysql_connect('162.209.63.14','rootHTC','dwyeR2260'); //
            if (!$link)
            {
                $Error = 'Could not connect: ' . mysql_error();
            }
            else
            {
                mysql_select_db('htcStateFair');


                if (mysql_query($strSQL))
                {
                    $Return = 'Success';
                }
                else{
                    $Return = 'Fail';
                }

                $Rows = mysql_affected_rows();
                if($Rows == 0)
                    $Return='Fail';

                return $Return;

            }

        }

       
    }
?>