<html>
	<head>
		<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.js"></script>
			
		<link rel="stylesheet" type="text/css" media="screen" href="./javascript/jqGrid/css/ui-lightness/jquery-ui-1.7.1.custom.css" />
		<link rel="stylesheet" type="text/css" media="screen" href="./javascript/jqGrid/css/ui.jqgrid.css" />
		 
		<script src="./javascript/jqGrid/js/jquery-1.4.2.min.js" type="text/javascript"></script>
		<script src="./javascript/jqGrid/js/i18n/grid.locale-en.js" type="text/javascript"></script>
		<script src="./javascript/jqGrid/js/jquery.jqGrid.min.js" type="text/javascript"></script>

		
		<style>
			html, body {
				margin: 0;
				padding: 0;
				font-size: 75%;
			}
		</style>
	
		<script type = "text/javascript">
			$(function(){ 
				$("#list").jqGrid({
					url:'viewVisitorsDB.php?XDEBUG_SESSION_START=session_name',
					datatype: 'json',
					mtype: 'GET',
					colNames:['Company'],
					colModel :[ 
					  {name:'company', index:'company', width:55}, 
					],
					pager: '#pager',
					rowNum:10,
					rowList:[10,20,30],
					sortname: 'company',
					sortorder: 'desc',
					viewrecords: true,
					caption: 'Visitors'
			  }); 
			}); 

		</script
	
	</head>
	
	<body>

	

	</body>
</html>




