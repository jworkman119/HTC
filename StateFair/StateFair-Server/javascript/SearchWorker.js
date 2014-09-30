/**
 * Created by patterj on 7/30/14.
 */


$(document).ready(function() {
    /*** - Global Variables - *****/
        var myArr = [];
        var WorkerID="";
        var EditID = 0;
        var currentRow="";
        var Status="";
        var ScheduleID = 0;

    /***** Jquery GUI setup - *****/
        $("#Accordion").accordion(
        {
            collapsible: true,
            active: false
        });

    /* Adding icons to buttons in grid */
    $(".Edit").button({
        icons:
        {
        primary: "ui-icon-pencil"
        }
    });

    $(".Delete").button({
        icons:
        {
        primary: "ui-icon-trash"
        }
    });

    /*  Adding zones to combobox */
    addZones();
    $("#searchBox").focus();
    $("#searchBox").focus(function() { $(this).select(); } );


    /* returning the workers names for the search box */
    $.ajax({
        type: "GET",
        url: "xml/Workers.xml", // change to full path of file on server
        dataType: "xml",
        success: parseNames,
        complete: setupAC,
        failure: function(data) {
        alert("XML File could not be found");
        }
    });

    /* Adding default press of enter key to search textbox */
    $("#searchBox").keyup(function(event){
        if(event.keyCode == 13){
            $("#butSubmit").click();
        }
    });

    /*** - Form to Add/Edit Data ***/
    $("#dbForm").dialog({
        autoOpen: false,
        height: 280,
        width: 400,
        modal: true,
        buttons:{
            Update: function()
            {
                var Pass = checkDBForm();
                if(Pass == 0)
                {
                updateDB();

                }
            },
            Cancel: function(){
                resetDBForm();
                $("#dbForm").dialog("close");
                currentRow="";
                }
        }

    });

    /*** - Delete GUI - ****/
    $("#deleteForm").dialog({
        autoOpen: false,
        height: 150,
        width: 275,
        modal: true,
        buttons:{
            Delete: function(){
            deleteRow();
            currentRow="";
            },
            Cancel: function(){
                $("#deleteForm").dialog("close");
                currentRow="";
                }
        }
    });

    $("button.Delete").button().click(function(){

        var objTD = $(this).parent().parent().children();
        EditID = objTD[0].innerHTML;
        Status = objTD[6].innerHTML;
        currentRow = objTD;

        $("#deleteForm").dialog("open");
    });
    /**** - End Delete GUI- ****/

    $('#butSubmit').click(function(){
        clearTable();
        setupDetails();

        var Active = $( ".selector" ).accordion( "option", "active" );
        if(Active !=1)
        {
        $('#Accordion').accordion("option", "animate", 200)
        $('#Accordion').accordion("option", "active", 1);
        }

    });

    $("button.Edit").button().click(function(){
        resetDBForm();
        currentRow = "";

        if(currentRow=="")
        {
            $("#frmEntry option[value='Scheduled']").attr("disabled", false);
            var objTD = $(this).parent().parent().children(); //$("#tblSchedule tr").eq(row_index);  //
            $("#frmDate").val(objTD[1].innerHTML);
            EditID = objTD[0].innerHTML;
            var EditStatus = objTD[6].innerHTML;


            // we are working from a previous entered Row
            if (EditID != "")
            {
                setupForm_UpdateRow(objTD,EditStatus)
            }
            else
            {
                EditID=0;
            }
            // Keeping the current Row in memory so it can be used for updating
            currentRow = objTD;

        }


        $("#dbForm").dialog("open");

    });

    $("#butSchedule").button().click(function()
    {
        printSchedule();

    });

    function printSchedule()
    {
            $('#spinner').show();
            var returnValue = 0;
            var objXHR = $.ajax({
                type: 'Post'
                , url: "./php/exportPersonSchedule.php"
                , data: "WorkerID=" + WorkerID
                , error: function()
                {
                    displayDBStatus("Fail", "Report Failed, please try printing again");
                }
                , complete: function(objXHR)
                {
                    displayDBStatus("Pass", "Report Created");
                    var pdf = './Export/pdf/' + objXHR.responseText;
                    window.location.href = pdf;
                    $('#spinner').hide();
                }

            });
    }

    $("#frmStatus").change(function(){
        var strStatus =  $("#frmStatus").val();
        if(strStatus=="Worked")
        {
            $("#frmZone").hide();
            $("#lblZone").hide();

            ScheduleID = EditID;
            EditID=0;
        }
        else
        {
            $("#frmZone").show();
            $("#lblZone").show();

            EditID=ScheduleID;
            ScheduleID=0;
        }
    });


    /***** - End Jquery GUI setup - *****/

    function addZones()
    {
        var SQL = "SQL=Select Zone.ID, concat(Zone.ID,' - ',Zone.Description) as Zone From Zone Order by ID";
        callDatabase(SQL,'addZones');
     }


    /* adds value to array to be used in search box */
    function parseNames(xml)
    {
        //find every query value
        $(xml).find("Worker").each(function()
        {
            myArr.push($(this).find("FullName").text());
        });
    }

    function setupAC()
    {
        $("input#searchBox").autocomplete({
            source: myArr,
            minLength: 1,
            select: function(event, ui) {
                $("input#searchBox").val(ui.item.value);
            }
        });
    }

    /* sets up the auto-complete for search box */

    /*** - Details Section - ***/
    function parseID(xml)
    {
        var Name = $("input#searchBox").val();
        //find every query value
        $(xml).find("Worker").each(function(){
            var newName = $(this).find("FullName").text();
            if(newName == Name)
            {
            WorkerID = $(this).find("ID").text();
            }
        });
    }

    function fillInDetails()
    {
        var strSQL = "SQL=call returnWorkerInfo(" + WorkerID + ")&Result=Result";
        var objXHR = $.ajax({
            type: 'Post'
            , url: "./php/returnWorkerInfo.php"
            , data: strSQL
            , dataType: 'json'
            , complete: function(objXHR)
            {
            var jsonData = formatJSON(objXHR.responseText, 'fillInDetails');
            addDetailsData(jsonData);
            }
        });
    }

    function setupDetails()
    {
        $.ajax({
            type: "GET",
            url: "xml/Workers.xml",
            dataType: "xml",
            success: function(result){
                var Response = result;
                parseID(Response);
                fillInSchedule();
            }
        });
    }

    function addDetailsData(jsonData)
    {
        jsonData = formatJson_PicPath(jsonData);
        $("#pictureBox").attr('src',jsonData[0].PicPath);
        $("#name").text(jsonData[0].Person);
        $("#gender").val(jsonData[0].Gender);
        $("#under18").val(jsonData[0].Under18);
        $("#drive").val(jsonData[0].Driver);
        $("#phone").val(jsonData[0].Phone)
        $("#Job").text(jsonData[0].Job)
    }
    /*** - End Details Section - ***/

    function resetDBForm()
    {
        $("#trTiAmPm").slideUp();
        $("#trToAmPm").slideUp();
        $("#frmDate").val('');
        $("#frmTimeIn").val('');
        $("#frmTimeOut").val('');
        $("#frmZone").val(0);
        $("#frmStatus").val(0);

        $("#lblZone").css('color','black');
        $("#lblFrmStatus").css('color','black');

        $("#lblTimeIn").css('color','black');
        $("#lblTimeIn").text('Time In');

        $("#lblTimeOut").css('color','black');
        $("#lblTimeOut").text('Time Out');
        $("#frmStatus option[value='Scheduled']").attr("disabled", false);

    }

    function checkDBForm()
    {
        var ReturnValue = 0;
        var intTI_AMPM = $("#frmTimeIn").val().toLowerCase().indexOf('am') + $("#frmTimeIn").val().toLowerCase().indexOf('pm');
        var intTO_AMPM = $("#frmTimeOut").val().toLowerCase().indexOf('am') + $("#frmTimeOut").val().toLowerCase().indexOf('pm');
        var currentStatus = $("#frmStatus").val();

        if($("#frmStatus option:selected").index() == -1)
        {
            // change label to red font
            $("#lblFrmStatus").css('color','red');
            ReturnValue = -1;
        }
        else if(intTI_AMPM<0)
        {
            //change label to red font, no am or pm
            $("#lblTimeIn").css('color','red');
            $("#trTiAmPm").slideDown("slow");

            ReturnValue = -1;
        }
        else if(intTO_AMPM<0)
        {
            if(currentStatus!='Worked' && $("#lblTimeOut").length >0)
            {
            $("#lblTimeOut").css('color','red');
            $("#trToAmPm").slideDown("slow");

            ReturnValue = -1;
            }
        }
        else if($("#frmZone option:selected").index == -1 && CurrentStatus=="Scheduled")
        {
            // change label to red font.
                $("#lblZone").css('color','red');
                ReturnValue = -1;
        }
        return ReturnValue;
    }

    function addToComboBox(jsonData)
    {
        for(var j=0; j< jsonData.length;j++)
        {
            var Data = jsonData[j];
            $("<option value ="+ Data.ID  + ">" + Data.Zone + "</option>" ).appendTo("#frmZone");
        }

    }

    function formatJSON(strJSON, strFunction)
    {

        if(strFunction=='fillInDetails')
        {
            var Start = strJSON.indexOf('[');
            var End = strJSON.indexOf(']');
            strJSON = strJSON.substring(Start + 1,End);
        }

        var jsonData = $.parseJSON(strJSON);

        return jsonData;
    }

    function formatJson_PicPath(jsonData)
    {
        var picpath = jsonData[0].PicPath;
        // Need to adjust path, had to use @ instead of /
        // because $.parseJSON function will not work
        picpath = picpath.replace(/@/gi,'\/');

        //pic path needs to be adjusted from full path to partial path so
        // image will load
        picpath = picpath.replace('/srv/http/StateFair','.');
        jsonData[0].PicPath = picpath;
        return jsonData;
    }

        /* Todo - should probably rename function */
    function fillInSchedule()
    {
        var strSQL = "SQL= call returnSchedule_Times(" + WorkerID + ")&Result=Result";
        var objXHR = $.ajax({
            type: 'Post'
            , url: "./php/returnWorkerInfo.php"
            , data: strSQL
            , dataType: 'json'
            , complete: function(objXHR)
            {
            var jsonData = formatJSON(objXHR.responseText, 'fillInSchedule');
            addDetailsData(jsonData);
            fillInTable(jsonData, 'Scheduled');
            }
        });

    }


    /***** - Database Section - Used for database calls and displaying status - ****/
    function updateDB()
    {
        var Date =  $("#frmDate").val();
        var TimeIn = formatTime(Date,$("#frmTimeIn").val());
        var TimeOut = null;
        var Test = $("#frmTimeOut").val().length;
        if(Test>0)
        {
            TimeOut = formatTime(Date,$("#frmTimeOut").val());
        }

        var ID = EditID;
        var SQL = "";
        //Updating global, so it can be passed back to updateGrid()
        Status = $("#frmStatus").val();

        if(Status =="Worked")
        {
            if (EditID>0)
            {
                SQL = "SQL=call updateTime_Manually(" + ID + ",'"+ TimeIn.trim() + "','" + TimeOut.trim() + "')&Result=Result";
            }
            else /* EditID = 0, we have a new row in Time */
            {
                if (TimeOut!=null)
                {
                    SQL = "SQL=call addTime_Manually(" + WorkerID + ",'"+ TimeIn.trim() + "','" + TimeOut.trim() + "')&Result=Result";
                }
                else
                {
                    SQL = "SQL=call addTime_Manually(" + WorkerID + ",'"+ TimeIn.trim() + "',null)&Result=Result";
                }
            }
        }
        else if(Status =="Scheduled")
        {
            var Zone = $("#frmZone").val();
            if(EditID>0)
            {

            SQL = "SQL=call updateSchedule_Manually(" + ID + ",'"+ TimeIn.trim() + "','" + TimeOut.trim() + "','" + Zone +  "')&Result=Result";
            }
            else /* EditID = 0, we have a new row in Schedule */
            {
                /*changing Times to h:m */
                TimeIn = shortTime(TimeIn);
                TimeOut=shortTime(TimeOut);
                Date=formatDate(Date);
                SQL = "SQL=call addSchedule_Manually(" + WorkerID + ",'"+ Date + "','"+ TimeIn.trim() + "','" + TimeOut.trim() + "','" + Zone +  "')&Result=Result";
            }
        }

        callDatabase(SQL,"updateDB");
    }

    function callDatabase(strSQL, strFunction)
    {
        var objXHR = $.ajax({
            type: 'Post'
            , url: "./php/returnWorkerInfo.php"
            , data: strSQL + "&Result=Result"
            , dataType: 'json'
            , error: function()
            {
            $("#dbForm").dialog("close");
            displayDBStatus("Fail","There was an error, the database did not update.");
            }
            , complete: function(objXHR)
            {
                if (objXHR.responseText !='null')
                {
                var jsonData = formatJSON(objXHR.responseText, strFunction);
                if(strFunction=='fillInDetails')
                {
                addDetailsData(jsonData);
                }
                else if(strFunction=='addZones')
                                        {
                                            addToComboBox(jsonData);
                                            }
                else if(strFunction=="updateDB")
                                        {
                                            updateGrid(jsonData)
                                            currentRow=="";
                                            $("#dbForm").dialog("close");
                                            displayDBStatus("Pass","The database was successfully updated.");
                                            }
                }
                else
                                    {
                                        $("#dbForm").dialog("close");
                                        displayDBStatus("Fail","There was an error, the database did not update.");
                                        }

                }


        });

    }

    function callDatabase_NoReturn(strSQL, strFunction)
    {
        var returnValue = 0;
        var objXHR = $.ajax({
            type: 'Post'
            , url: "./php/returnWorkerInfo.php"
            , data: strSQL
            , error: function()
            {
            $("#deleteForm").dialog("close");
            displayDBStatus("Fail", "Delete Failed, the data was not removed from the database");
            }
            , complete: function(objXHR)
            {
                if (strFunction=="deleteRow")
                {
                $("#deleteForm").dialog("close");
                displayDBStatus("Pass", "The data was removed from the database");
                }
            }
        });

    }

    function displayDBStatus(strStatus, strMsg)
    {
        if(strStatus=="Pass")
        {
        $("#lblStatus").css('color','black');
        }
        else
        {
            $("#lblStatus").css('color','red');
        }

        $("#lblStatus").text(strMsg);
        $("#lblStatus").show().delay(3000).fadeOut();

        resetDBForm();
    }
    /*** - End Database Section - ****/


    /*** - Grid Section - ****/
    function updateGrid(jsonData)
    {
        currentRow[2].innerHTML = jsonData[0].TimeIn;
        currentRow[3].innerHTML = jsonData[0].TimeOut;
        currentRow[5].innerHTML = jsonData[0].Hours;
        currentRow[6].innerHTML = Status;

        if(jsonData[0].Zone!=undefined)
        {
        currentRow[4].innerHTML = jsonData[0].Zone;
        }
        if(jsonData[0].ID != undefined)
        {
            currentRow[0].innerHTML = jsonData[0].ID;
        }
    }

    function updateGrid_DeleteRow()
    {
        for(var j = 0; j<currentRow.length -2;j++)
        {
            if(j!=1  )
            {
            $(currentRow[j]).text('');
            }
        }
    }

    function setupForm_UpdateRow(objTD, Status)
    {
        $("#frmStatus").val(Status);

        if(Status=="Worked")
        {
            $("#frmStatus option[value='Scheduled']").attr("disabled", true);
            $("#frmZone").hide();
            $("#lblZone").hide();
        }
        else
        {
            $("#frmStatus option[value='Scheduled']").attr("disabled", false);
            $("#frmZone").show();
            $("#lblZone").show();
        }

        $('#dbForm').dialog('option', 'title', 'Edit Time ' + Status);
        $("#frmTimeIn").val(objTD[2].innerHTML);
        $("#frmTimeOut").val(objTD[3].innerHTML);
        var Zone = objTD[4].innerHTML;
        Zone = Zone.substring(0,Zone.indexOf("-") -1)
        $("#frmZone").val(Zone);

    }

    function deleteRow()
    {
        if(currentRow !="" && EditID!="")
        {
            var SQL;
            if(Status=="Scheduled")
            {
                SQL = "SQL=Delete from Schedule where ID = " + EditID + "&Result=NoResult";
            }
            else
            {
                SQL = "SQL=Delete from Time where ID = " + EditID + "&Result=NoResult";
            }

            callDatabase_NoReturn(SQL, "deleteRow");
            displayDBStatus("Pass", "The data was successfully removed from the database");
            updateGrid_DeleteRow();

        }
    }

    function clearTable()
    {
        $("#tblBody tr").each(function(){
            this.children[0].innerHTML='';
            this.children[2].innerHTML='';
            this.children[3].innerHTML='';
            this.children[4].innerHTML='';
            this.children[5].innerHTML='';
            this.children[6].innerHTML='';
        });
    }

    function fillInTable(jsonData, Status)
    {
        clearTable();
        for(var j=0; j< jsonData.length;j++){
            var Data = jsonData[j];
            $("#tblBody tr").each(function(){
                var Date = this.children[1].innerHTML;
                var Day = Data.Day;

                if(Day.substring(0,1)=='0')
                {
                    Day = Day.substring(1,Day.length)
                }

                if(Date == Day)
                {
                    this.children[0].innerHTML = Data.ID;
                    this.children[2].innerHTML = Data.TimeIn;
                    this.children[3].innerHTML = Data.TimeOut;
                    this.children[4].innerHTML = Data.Zone;
                    this.children[5].innerHTML = Data.Hours;
                    this.children[6].innerHTML = Data.Status;

                    return false;
                 }
            });
        }

    }
    /*** - Grid Section - ****/

}); // end jquery



