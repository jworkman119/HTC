<?php

    require_once('QueryDB.php');
    $SQL = $_POST['SQL'];
    $recordset = Fill_ComboBox($SQL);
    $recordset = json_encode($recordset);
    echo $recordset;

    function Fill_ComboBox($strSQL)
    {

        $objDB = new QueryDB();
        $recordset = $objDB->queryMySQL($strSQL);

        return $recordset;
    }

?>