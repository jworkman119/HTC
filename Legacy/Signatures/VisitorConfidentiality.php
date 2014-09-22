<html>
<!--	?XDEBUG_SESSION_START=default -->

	<head>
		<title>HTC - Visitor Confidentiality and Non-Disclosure Agreement</title>

			<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.js"></script>
			<link rel="stylesheet" type="text/css" href="./css/SignaturePad/jquery.signaturepad.css">
    		<link rel="stylesheet" type="text/css" href="./css/SignaturePad/Main.css">
			<style type="text/css">
				
				#VisitorConfidentiality{
					float: left;
				}
				
				div.FormArea{
					margin-left: 150px;
					margin-right: auto;
				}

			</style>
			
			
			
			<script type="text/javascript" src="./javascript/jquery.signaturepad.min.js"></script>
    		<script type="text/javascript" src="./javascript/json2.min.js"></script>
			<script type="text/javascript" src="./javascript/VisitorConfidentiality.js"></script>

	</head>

	<body>
		<img src='./images/HTC_logo-small.png'/>
		<hr class='banner'/>
		<br>
		<Header>
			<h2>Visitor Confidentiality and Non-Disclosure Agreement</h2>
		</Header>
		
		<p>
			<ol>
				<li>
					I, as a visitor at Human Technologies Corporation(HTC), understand that I may see or otherwise be given access to
					, confidential information belonging to HTC, through my relationship with HTC or as a result of my access to HTC's
					premises.
				</li>
			
				<br>
			
				<li>
					I understand and acknowledge that HTC's confidential information and/or trade secrets consist of information and materials '
					that are valuable to HTC and not generally know to HTC's competitors or outsiders, including, but not limited to:
					<ol type = "i">
						<li>
							The names and identities of employees and volunteers I may see at HTC's premises.
						</li>
						
						<br>
						
						<li>
							Information concerning HTC's current, future or proposed products, including, but not limited to: computer hardware
							, software, codes, drawings, specifications, technical notes, computer printouts, and other proprietary technology.
						</li>
						
						<br>
						
						<li>
							Information and materials relating to HTC's business contracts, purchasing, accounting and marketing, quality control
							, inventory and shipping, pricing information and customer lists.
						</li>
						
						<br>
						
						<li>
							All other types and categories of information not listed whether written, verbal, electronic or printed.
						</li>
						
					</ol>
				</li>
				
				<br>
				
				<li>
					In consideration of being admitted to HTC's facilities, I will hold in strictest confidence any confidential information that is disclosed
					to me. I will not remove any document, equipment or other materials from the premises without HTC's express permission. I will not photograph
					or otherwise record information which I may have access to during my visit.
				</li>
				
				<br>
			</ol>
		</p>
		
		<br>

		<div class = "FormArea">			
			<input type = "checkbox" id="chkAgree" >I agree to the above terms</input>
			<br>
			<br>
			
		
			<form action="" class="sigPad">
				<div id = "divSignature">	
					<ul class="sigNav">
						<li class="drawIt"><a href="#draw-it" >Sign Here</a></li>
						<li class="clearButton"><a href="#clear">Clear</a></li>
					</ul>

					<div class="sig sigWrapper">
						<canvas id="canvasPad" class="pad" width="300px" height="90px"></canvas>
						<input type="hidden" name="output" class="output"> 
					</div>
					<button type="button" id ="butSubmit">Sign In</button>
				</div>	
			</form>
		</div>	


	</body>
		
		
		
</html>