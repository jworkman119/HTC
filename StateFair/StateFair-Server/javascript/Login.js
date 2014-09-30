/**
 * Created by patterj on 7/30/14.
 */

$(document).ready(function() {
    $('#UserName').focus();

    $('#WrongPwd').hide();

    $('#Update').hide();

    $('input[name="textbox"]').addClass("idleField");
    $('input[name="textbox"]').focus(function() {
        $(this).removeClass("idleField").addClass("focusField");

        if(this.value != this.defaultValue){
            this.select();
        }
    });

    $('input[name="textbox"]').blur(function() {
        $(this).removeClass("focusField").addClass("idleField");

    });

    $('#Enter').click(function() {

        var SQL = returnSQL($('#UserName').val(), $('#password').val());

        callDatabase(SQL);
    });
});

    function returnSQL(strUserName, strPwd)
    {
        strPwd = $.md5(strPwd);
        var strSQL = "SQL=call checkPassword ('" + strUserName + "', '" + strPwd + "', @status)&Type=return";
        return strSQL;
    }

    function callDatabase(strSQL)
    {

        var objXHR = $.ajax({
            type: 'Post'
            , url: "./php/Login.php"
            , data: strSQL
            , dataType: 'json'
            , complete: function(objXHR)
            {

                var jsonData = formatJSON(objXHR.responseText);
                jsonData = $.parseJSON(jsonData);


                if (jsonData.Status == 'Fail')
                {
                    // create a label that says login failed using jquery
                    $( "#WrongPwd" ).dialog({
                        height: 140,
                        modal: true
                    });

                    clearPage();
                }
                else if(jsonData.Status =='Update')
                {
                    window.location='UpdatePwd.html';
                }
                else
                {
                    returnWorkersXML();
                    window.location='MainPage.html';
                }
            }
        });

    }

    function formatJSON(strJSON)
    {
        var Start = strJSON.indexOf('[');
        var End = strJSON.indexOf(']');
        strJSON = strJSON.substring(Start + 1,End);
        return strJSON
    }

    function returnWorkersXML()
    {
        var objXHR = $.ajax({
            type: 'Post'
            ,url: "./php/returnWorkersXML.php"
        });
    }

    function clearPage()
    {
        $('input[name="textbox"]').val('');
        $('#UserName').focus();
    }



