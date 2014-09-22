<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<!--	?XDEBUG_SESSION_START=default -->

	<head>

			<title>HTC - Visitor Information Form</title>

			<!-- CSS -->
			<link rel="stylesheet" type="text/css" href="./css/SignaturePad/jquery.signaturepad.css">
			<link rel="stylesheet" type="text/css" href="./css/SignaturePad/VisitorInfo.css">
			<link rel="stylesheet" type="text/css" href="./css/SignaturePad/Main.css">
			<!-- JavaScript -->
			<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.min.js"></script>
			<script type="text/javascript" src="./javascript/jquery.geolocation.js"></script>
		<!-- Move Javascript code to own file -->	

			<script type="text/javascript">
				
<!-- Move to own .js file -->				
				$(document).ready(function(){
				
				// Testing jquery geolocation
				/*
					if($.geolocation.support() == true){
							$.geolocation.find(function(location){
									var latitude = location.latitude;
									var longitue = location.longitude;
							});
					}			
					*/
					// End geolocation testing
				
					$('input:text:first').focus();
										
					$('#butSubmit').click(function(){
						var	strFirst = toTitleCase($('#txtFirst').val());
						var	strLast = toTitleCase($('#txtLast').val());
						var strBadge = $('#txtBadge').val();
						var	strCompany = $('#txtCompany').val().toUpperCase();
						var objArray = {'Variables[]':[strFirst, strLast, strBadge, strCompany]};
						
						var objXHR = $.ajax({
							type: 'POST'
							, url: 'VisitorStatus.php?XDEBUG_SESSION_START=session_name'
							, data: {First:strFirst,Last:strLast,Badge:strBadge, Company:strCompany}
							, complete: function(objXHR){

								if ($.isArray(objXHR.respeonseText)== true){
									//Load array into grid w/ radio buttons, reload page
								}
								else //Load Page
								{
									var strURL = objXHR.responseText + '?First=' + strFirst + '&Last=' + strLast + '&Badge=' + strBadge + '&Company=' + strCompany;
									window.location = strURL;
									//$.load(objXHR.responseText);
								}
							}
						});

					});
	
			
				});
				
				function toTitleCase(str)
				{
					return str.replace(/\w\S*/g, function(txt){return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();});
				}

			</script>

	</head>
	
	<Body>
		<div class = 'banner'>
			<img src='./images/HTC_logo-small.png'/>
			<hr class='banner'/>
			<br>
			<Header>
				<h2>Visitor Information Form</h2>
			</Header>
		</div>
		<div id='wrap'>
				<form class='VisitorInfo'>
						<div class='colLeft'>
							<p>
								<label for='FirstName' class='lblLeft'>
									First Name:
								</label>
								
								<input type='text' name='FirstName' class='txtLeft' id='txtFirst' tabindex = '1'/>
							</p>
							
							<p>
								<label for='Badge' class='lblLeft'>
									Badge #:
								</label>
								
								<input type='text' name='Badge' class='txtLeft' id='txtBadge' tabindex = '3'>
							</p>
						</div>

						<div class='colRight'>
							<p>
						
								<label for='LastName' class='lblRight' >
									Last Name:
								</label>

								<input type='text' name='LastName' class='txtRight' id='txtLast'tabindex = '2'/>
							</p>
							
							<p>
								<label for='Company' class='lblRight'>
									Company:
								</label>
						
								<input type='text' name='Company' class='txtRight' id='txtCompany' tabindex = '4'/>
							</p>
						</div>
					
					<br>
					<br>
					<p class = 'butSubmit'>
						<button class='butSubmit' type="button" id ="butSubmit" tabindex='5'>Enter</button>
					</p>
				</form>
		</div>
		
		
	</Body>
</html>