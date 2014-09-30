/**
 * Created by patterj on 7/30/14.
 */

$(function(){
    $('#fromDate').datepicker({ dateFormat: "mm-dd-yy" });
    $('#toDate').datepicker({ dateFormat: "mm-dd-yy" });
    $('#svpDate').datepicker({ dateFormat: "mm-dd-yy" });
    $('#startDate').datepicker({ dateFormat: "mm-dd-yy"})
    $('#endDate').datepicker({ dateFormat: "mm-dd-yy"})



    /*********** - Radio Buttons - ****************/
    $('#Payroll').click(function()
        {
            $('#divRosterSheet').hide('fast');
            $('#divScheduleVsPunches').hide('fast');
            $('#divDownloadSchedule').hide('fast');
            $('#divDailyPayroll').show('slow');
        }
    );

    $('#Roster').click(function()
        {

            $('#Date').datepicker({ dateFormat: "mm-dd-yy" });
            var strPage = './php/FillCombobox.php'
            var strSQL = "SQL= Select ID,concat(Person.FirstName, ' ' , Person.LastName)as Person from Person Where Role_ID = 'sup' order by Person.Firstname"
            CallDatabase('Fill_ComboBox',strSQL, strPage);

            $('#divDailyPayroll').hide('fast');
            $('#divScheduleVsPunches').hide('fast');
            $('#divDownloadSchedule').hide('fast');
            $('#divRosterSheet').show('slow');
        }
    );
    $('#ScheduleVsPunches').click(function()
        {
            $('#divDailyPayroll').hide('fast');
            $('#divRosterSheet').hide('fast');
            $('#divDownloadSchedule').hide('fast');
            $('#divScheduleVsPunches').show('slow');
        }

    );
    $('#DownloadSchedule').click(function()
        {
            $('#divDailyPayroll').hide('fast');
            $('#divRosterSheet').hide('fast');
            $('#divScheduleVsPunches').hide('fast');
            $('#divDownloadSchedule').show('slow');
        }

    );


    //Setting default radio button to CreateShift
    $('input:radio').filter("[ID='Roster']").trigger('click');

    /********** - End Radio Buttons - *************/



    $('#butGetReport').click(function(){
        $('.spinner').show();
        var strReport = $('input[name=ReportType]:checked').val()



        if (strReport == 'Roster')
        {
            RosterSheets();
        }
        else if (strReport == 'Payroll')
        {
            DailyPayroll();
        }
        else if (strReport == 'ScheduleVsPunches')
        {
            ScheduleVsPunches();
        }
        else if (strReport == "DownloadSchedule")
        {
            DownloadSchedule();
        }



    });

    function RosterSheets()
    {
        var strShift = $('#cmbShifts').val();
        var strDate = $('#Date').val();
        if (strShift == 'Select')
        {
            alert('Please select a supervisor.');
            $('#cmbShifts').focus();
        }
        else if(strDate =='')
        {
            alert('Please select a day.')
            $('#Date').focus();
        }
        else
        {

            var strData = 'Day=' + $('#Date').val();
            strData = strData + '&Person=' + $('#cmbSupervisor').val();
            var strPage = './php/exportRosterSheets.php';
            CallDatabase('returnRosterSheets',strData,strPage);

        }
    }


    function DailyPayroll()
    {
        var intFrom = $("#fromDate").val().length;
        var intTo = $("#toDate").val().length;

        if(intFrom <= 0)
        {
            alert("You did not enter a From Date.");
            $("#fromDate").focus();
        }
        else if(intTo <=0)
        {
            alert("You did not enter a To Date.")
            $("#toDate").focus();
        }
        else
        {
            var strData = 'FromDate=' + $('#fromDate').val() + '&ToDate=' + $('#toDate').val();
            CallDatabase('returnPayroll',strData,'./php/exportPayroll.php');
        }
    }

    function ScheduleVsPunches()
    {
        var intDate = $('#svpDate').val().length;

        if(intDate <=0)
        {
            alert("You did not enter a date.");
            $("#svpDate").focus();
        }
        else
        {
            var strData = 'svpDate=' + $('#svpDate').val();
            CallDatabase('ScheduleVsPunches',strData,'./php/exportScheduleVsPunches.php');
        }

    }

    function CallDatabase(strFunction,strData, strPage)
    {
        $.ajax({
            type: 'POST'
            , url: strPage
            , data: strData
            , complete: function(objXHR){
                if (strFunction == 'Fill_ComboBox')
                {
                    var jsonData = $.parseJSON(objXHR.responseText);
                    // clearing combobox
                    $('#cmbSupervisor>option').remove();
                    $('#cmbSupervisor').append($('<option></option>').val('Select').html('Select'));

                    //adding values from database
                    for(var j=0;j< jsonData.length;j++){

                        $('#cmbSupervisor').append(
                            $('<option></option>').val(jsonData[j].ID).html(jsonData[j].Person)
                        );
                    }
                }// end fill combobox
                else if(strFunction == 'returnRosterSheets')
                {
                    //     $('*').css('cursor','default');
                    var pdf = './Export/pdf/' + objXHR.responseText;
                    window.location.href = pdf;
                }
                else if(strFunction == 'returnPayroll' || strFunction =='ScheduleVsPunches')
                {
                    //    $('*').css('cursor','default');
                    var csv = './Export/excel/' + objXHR.responseText;
                    window.location.href = csv;
                }
                else if(strFunction == 'DownloadSchedule')
                {
                    var xls = './Export/excel/' + objXHR.responseText;
                    window.location.href = xls;
                }

                $('.spinner').hide();
            }
        });

    }

    function DownloadSchedule()
    {
        var intStart = $("#startDate").val().length;
        var intEnd = $("#endDate").val().length;

        if(intStart <= 0)
        {
            alert("You did not enter a Start Date.");
            $("#startDate").focus();
        }
        else if(intEnd <=0)
        {
            alert("You did not enter a To Date.")
            $("#endDate").focus();
        }
        else
        {
            var strData = 'StartDate=' + $('#startDate').val() + '&EndDate=' + $('#endDate').val();
            CallDatabase('DownloadSchedule',strData,'./php/exportSchedule.php');
        }
    }

});
