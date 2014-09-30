/**
 * Created by patterj on 7/30/14.
 */
$(function() {
    $( "#StartDay" ).datepicker();
    $( "#EndDay" ).datepicker();
    $("#Parse").hide('fast');
    $("#Finish").hide('fast');
    $('#file_upload').fileupload({
        url: 'php/importSchedule.php',
        done: function (e, data) {
            $Pass = data.result;
            if($Pass="Uploaded")
            {
                $("#Upload").hide('slow');
                $("#Parse").show('slow');
            }
        }
    });

    $("#butUpdate").click(function()
    {
        $("#Parse").hide('slow');
        $("#Finish").show('slow');
        setCursorByID("Finish","wait");
        var strData = 'StartDate=' + $('#StartDay').val() + '&EndDate=' + $('#EndDay').val();
        passDates(strData);
        setCursorByID("Finish","default");
    });

    function CheckFileName() {
        var fileName = document.getElementById("txtFile").value;
        var strPass;
        if (fileName == "") {
            alert("Browse to upload a valid File with .xls extension");
            strPass = false;
        }
        else if (fileName.split(".")[1].toLowerCase() == "xls")
            strPass =  true;
        else {
            alert("File with " + fileName.split(".")[1] + " is invalid. Upload a validfile with .xls extensions");
            strPass = false;
        }
        return strPass;
    }

    function passDates(strData)
    {

        $.ajax({
            type: 'POST'
            , url: './php/importSchedule.php'
            , data: strData
            , datatype:'json'
            , cache: false
            , success: function(result){
                var Response = result;
                showResults(Response);
            }
        });
    }

    function showResults(strResults)
    {

        var strAppend='';
        var Row = '';
        if(strResults == 'Success')
        {
            strAppend='<p>All workers have been succesfully entered in the system.</p>'
        }
        else
        {
            var strFails = '<p>The following people were not entered into the schedule, please enter manually.</p><br>';
            strFails = strFails +  '<table><tr><td ><b><u>Person<u></b></td><td><b><u>Day</u></b></td><td><b><u>Zone</u></b></td><td><b><u>Time</u></b></td></tr>';
            var Fails = $.parseJSON(strResults);
            for(var i = 0; i < Fails.length;i++)
            {
                Row = '<tr><td>' + Fails[i].Person + '</td><td>' + Fails[i].Day + '</td><td>' + Fails[i].Zone + '</td><td>' + Fails[i].Time + '</td></tr>'
                strFails = strFails + Row;
            }
            strAppend = strFails + "</table>";
        }
        $("#lblWait").hide('fast');
        $("#Finish").append(strAppend);

    }

    function setCursorByID(id,cursorStyle)
    {
        var elem;
        if (document.getElementById &&
            (elem=document.getElementById(id)) ) {
            if (elem.style) elem.style.cursor=cursorStyle;
        }
    }

});

