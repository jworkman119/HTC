$.extend($('.sigPad').signaturePad.defaults, {
		 lineTop:75
});

// Read a page's GET URL variables and return them as an associative array.
function getUrlVars()
{
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for(var i = 0; i < hashes.length; i++)
    {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}
	
$(document).ready(function(){
	var api = $('.sigPad').signaturePad({drawOnly:true});


	var arVariables = getUrlVars();
	var First = arVariables["First"]; 
	var Last = arVariables["Last"];
	var Badge = arVariables["Badge"];
	var Company = arVariables["Company"];
	var Document = 'SignIn.php';

	$('#butSubmit').click(function(){
		var img = api.getSignatureString();
		var iLength = img.length;
		
		//$.post("processDB.php",{img:img},function(objXHR){alert(objXHR.responseText)});
		if (img.length > 2){
			var objXHR = $.ajax({
				type: 'POST',
				url:  'processDB.php?XDEBUG_SESSION_START=session_name',
				data: 'Img=' + img + '&First=' + First + '&Last=' + Last + '&Badge=' + Badge + '&Company=' + Company + '&Document='+Document,
				complete: function(objXHR){
					alert(objXHR.responseText);
					window.location = 'VisitorInfo.php';
				}
			});
		}
		else{
			alert("You did not sign, the document.");
			var options = {lineColour:'#FF0000'};
			$('.sigPad').signaturePad.lineColour='#FF0000';

		}
		
	});

});


