<?php
class clsTime
{
    // creates timestamp based of Date and time
    public function createTimeStamp($strDate, $strTime)
    {
        if ($strTime != null or $strTime !='' )
        {
            //$TimeStamp = Verify_DateTime($strDate . ' ' . $strTime);
            $strDate =str_replace('-','/',$strDate);
            $strDate = date('Y-m-d',strtotime($strDate));
            $strTime = strftime('%T', strtotime($strTime));
            $date = strtotime($strDate . ' ' . $strTime);
            $TimeStamp = date('Y-m-d G:i:s', $date);
        }
        else
        {
            $TimeStamp = null;
        }

        return $TimeStamp;
    }

    // will add day to time out if time runs over midnight. ex: 11:15 pm - 5:00am
    public function  checkTimeOut($strTimeIn, $strTimeOut)
    {
//        $TimeIn = strtotime($strTimeIn);//strtotime(substr($strTimeIn,strlen($strTimeIn) - 5,5));
        if($strTimeOut != null)
        {
            $TimeIn = strtotime($strTimeIn);
            $TimeOut = strtotime($strTimeOut);//strtotime(substr($strTimeOut,strlen($strTimeOut) - 5,5));
            if($TimeOut<$TimeIn)
            {
                $strTimeOut = date('Y-m-d G:i:s' ,strtotime('+1 day',strtotime($strTimeOut)));
            }
        }
        return $strTimeOut;
    }
}
