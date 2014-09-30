$(function(){

        $( 'input: button').button();

        $('button').hover(
                function(){
                    $(this).addClass('ui-state-hover');
                },
                function(){
                    $(this).removeClass('ui-state-hover');
                }
        )


/*********** - Radio Buttons - ****************/

        $('#EditShift').click(function()
            {
                CallDatabase('Fill_ComboBox', "Function=Fill_ComboBox");

                $('#divEditShift').show('slow');
                $('#divCreateShift').hide('slow');
            }
        );

         $('#CreateShift').click(function()
            {

                $('#divEditShift').hide('fast');
                $('#divCreateShift').show('slow');
            }
        );


         //Setting default radio button to CreateShift
         $('input:radio').filter("[ID='CreateShift']").trigger('click');

/********** - End Radio Buttons - *************/

/********** - ComboBox - *********************/
/*
            $( "#cmbShift" ).selectbox();
            $( "#toggle" ).click(function() {
                $( "#cmbShift" ).toggle();
            });
*/
        $('#cmbShift').change(function(){
                var strShift = $('#cmbShift').val();
                if (strShift != 'Select'){
                    var strPass = 'Function=Fill_TextBoxes&ShiftName=' + strShift;
                    CallDatabase('Fill_TextBoxes',strPass);
                }

        });

/********* - End Combox - ********************/

/*********** - Time Picker - ******************/
        // Use default settings
        $('#StartTime').timePicker(
            {
                startTime: '12:00 AM',
                endTime: '11:00 PM',
                show24Hours:false,
                separator: ':',
                step: 30
            }
        );
        $('#EndTime').timePicker(
            {
                startTime: '12:00 AM',
                endTime: '11:00 PM',
                show24Hours:false,
                separator: ':',
                step: 30
            }
        );



        // Store time used by duration.
        var oldTime = $.timePicker('#StartTime').getTime();

        // Keep the duration between the two inputs.
        $('#StartTime').change(function() {

          if ($('#EndTime').val()) { // Only update when second input has a value.
            // Calculate duration.
            var duration = 28800000;
            var time = $.timePicker('#StartTime').getTime();
            // Calculate and update the time in the second input.
            $.timePicker('#EndTime').setTime(new Date(new Date(time.getTime() + duration)));

          }
        });

        // Validate.
        $('#EndTime').change(function() {

          if($.timePicker('#StartTime').getTime() > $.timePicker('#EndTime').getTime()) {
            //$(this).addClass('error');
            //  var time = new Date($.timePicker('#StartTime').getTime());

            //    $.timePicker('#EndTime').setTime(time);
          }
          else {
            $(this).removeClass('error');
          }
        });
/************ - End TimePicker - ****************/

/************ - Button Enter - *****************/
        $('#butEnter').click(function() {
           var isChecked = $('input:radio').filter("[ID='CreateShift']").attr("checked") == "checked";
            var intLength = $("#txtShift").val().length;
            var TimeIn = $.timePicker('#StartTime').returnTimeString();
            var TimeOut = $.timePicker('#EndTime').returnTimeString();
            var ShiftName = $('#txtShift').val();

            if(isChecked == true){
                if (intLength > 0){

                    var strPass = 'Function=Add_Shift&ShiftName=' + $('#txtShift').val() + '&TimeIn=' + TimeIn +'&TimeOut=' + TimeOut;
                    CallDatabase('Add_Shift',strPass);
                }
                else
                {
                    alert("You did not enter a shift name.")
                    $("#txtShift").focus();
                }
            }
            else
            {
                var strPass = 'Function=Add_Shift&ShiftName=' + $('#cmbShift').val() + '&TimeIn=' + TimeIn +'&TimeOut=' + TimeOut;
                CallDatabase('Add_Shift',strPass);
            }
        });
        /************ - End Button Enter - *************/






        /************ - AJAX Function - **************/
            function CallDatabase(strFunction,strData)
            {

                var objXHR = $.ajax({
                    type: 'POST'
                    , url:  './php/CreateShift.php?XDEBUG_SESSION_START=session_name'
                    , data: strData
                    , dataType: 'json'
                    , complete: function(objXHR){

                        
                        if (strFunction == 'Fill_ComboBox')
                        {
                            var jsonData = $.parseJSON(objXHR.responseText);
                            // clearing combobox
                            $('#cmbShift >option').remove();
                            $('#cmbShift').append($('<option></option>').val('Select').html('Select'));
                            
                            //adding values from database
                            for(var j=0;j< jsonData.length;j++){

                                $('#cmbShift').append(
                                        $('<option></option>').val(jsonData[j].Name).html(jsonData[j].Name)
                                );
                             }
                        }/* end fill combobox */
                        else if (strFunction == 'Fill_TextBoxes')
                        {
                            var jsonData = $.parseJSON(objXHR.responseText);

                            for(var j=0;j< jsonData.length;j++) {
                                 $.timePicker('#StartTime').setTime(jsonData[j].TimeIn);
                                 $.timePicker('#EndTime').setTime(jsonData[j].TimeOut);
                             }
                        }
                        else if (strFunction == 'Add_Shift')
                        {
                            var isCreateShift = $('input:radio').filter("[ID='CreateShift']").attr("checked") == "checked";
                            var Response = objXHR.responseText;
                            if (Response == 'Success' || Response == '\nSuccess')
                            {
                                if (isCreateShift == true)
                                {
                                    alert('Your shift was successfully created.');
                                }
                                else
                                {
                                    alert('Your shift was successfully updated.')
                                }
                            }
                            else
                            {
                                alert('Your shift was not added to the db, please call IT.');
                            }

                            $("#txtShift").val("");
                            $("#cmbShift").val("Select");
                            
                        }
                    }
			    });
            }

        /********** - end AJAX - ********************/




});
