/**
 * Created by patterj on 6/30/14.
 */
function formatTime(Date, Time)
{
    var strAmPm;
    strAmPm =Time.substring(Time.length - 2);
    Time = checkLength(Time);

    if(strAmPm.toUpperCase() =='PM')
    {
        Time = addHours(Time);
    }
    else
    {
       Time = checkMidnight(Time);
    }
    Date = formatDate(Date);
    Time = Date + ' ' + Time;
    return Time
}

function checkLength(Time)
{
    Time = Time.substring(0,Time.length - 2)
    if(Time.length <= 2)
    {

        Time = Time + ":00";
    }

    return Time;
}

function addHours(Time)
{

    var Hours = Time.substring(0, Time.indexOf(":"));
    if(Hours!=12)
    {
        Hours = Number(Hours) + 12;
    }
    var Minutes = Time.substring(Time.indexOf(":"));
    Time = Hours + Minutes;
    return Time;
}

function shortTime(Time)
{
    arTime = Time.split(' ');
    return arTime[1];
}

function formatDate(Date)
{
    var arDate = Date.split("-");
    Date = arDate[2] + "-" + arDate[0] + "-" + arDate[1];
    return Date;
}

function checkMidnight(Time)
{
        if(Time.substring(0,2)==12)
        {
            var Min = '00';
            var Hour = '00';
            if(Time.indexOf(":")>0)
            {
                var arTime=Time.split(":")
                Min=arTime[1];
            }
            Time = Hour + ":" + Min;

        }

    return Time;
}