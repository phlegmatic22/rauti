<%@ Control Language="c#" Inherits="ForcedUpdate" CodeFile="ForcedUpdate.ascx.cs"%> 

<asp:Panel ID="Panel1" runat="server" style="z-index: 1; left: -3px; top: -4px; position: relative; height: 0px; width: auto">


<button class="button button5" onclick="myFunction('/dna/DNAreport/Viewer.aspx?report=_Templates/popup_trend'); return false;" style="vertical-align:middle"><span>Avaa graafi</span></button>
<link href="panelstyle2.css" type="text/css" rel="stylesheet">



<!-- load needed libraries: -->

<!-- <script type="text/javascript" src="/DNA/Exported/scripts/jquery-2.2.0.js"></script> -->
<script>

	
	var update_minute = <%=update_minute%>;
	var report_path = "<%=report_path%>";
	var report_path_prefix = "/dna/DNAreport/Viewer.aspx?report=";
	report_path = report_path_prefix + report_path;
	
	//console.log(report_path);
	var name = "";
	
	var loop_time = update_minute * 60 * 1000;
	var historyMode = false;
	
	var startDate;
	var endDate;

	var times = panelTimes();
	startDate = times[0];
	endDate = times[1];

	setInterval(function(){ 

		var thisMoment = new Date();
		var diffInMinutes = diff_hours(thisMoment, endDate);
		console.log("Now - enddate =",diffInMinutes," mins in the past" );
		if(diffInMinutes > 60){ console.log("Historymode activated."); historyMode = true; }
		
		var stString =startDate.format("YYYY/MM/DD HH:mm:ss");
		var etString =endDate.format("YYYY/MM/DD HH:mm:ss");
		var url = report_path;
		var aikataso = "";
		if(window.location.href.split('Aikataso=').length > 1){
			var jakso =window.location.href.split('&')[3].split('=')[1]
			var skaalaus =window.location.href.split('&')[4].split('=')[1]
			var aikataso =window.location.href.split('&')[5].split('=')[1]
			url = url + "&startTime=" +stString;
			url = url + "&endTime=" +etString;
			url = url + "&Jakso=" +jakso; 
			url = url + "&Skaalaus=" +skaalaus; 
			url = url + "&Aikataso=" +aikataso; 
		}
		else{
			url = report_path;
		}

		if(!(historyMode)){
			console.log("We're not in history -> update ... ");
			console.log(encodeURI(url));
			location = encodeURI(url);
		}
		else{
			console.log("We're in history -> don't update");
		}
		
	}, loop_time);
	
	function diff_hours(dt2, dt1) 
	 {
		console.log(dt2,dt1);
	  var diff =(dt2.getTime() - dt1.getTime()) / 1000;
	  diff /= (60);
	  return Math.round(diff);
	  
	 }
	 
	 function panelTimes() 
	 {
		var language = window.navigator.userLanguage || window.navigator.language;
		
		//alert(language); //works IE/SAFARI/CHROME/FF
		$('#startTime-div').datetimepicker(); 
		$('#endTime-div').datetimepicker();
		var stA = $('#startTime-div').data("DateTimePicker").date["_a"];
		var etA = $('#endTime-div').data("DateTimePicker").date["_a"];
		var st;
		var et;
		if(language == "en-US"){
			//console.log("DAWG");
			st = new Date(stA[0], stA[1] , stA[2] , stA[3], stA[4], 0);
			et = new Date(etA[0], etA[1] , etA[2] , etA[3], etA[4], 0);
		}
		else{
			st = new Date(stA[0], stA[2] - 1 , stA[1] + 1 , stA[3], stA[4], 0);
			et = new Date(etA[0], etA[2] - 1 , etA[1] + 1 , etA[3], etA[4], 0);
		}
		return [st,et];
	 }
</script>

<script>
function myFunction(url) {
  var myWindow = window.open(url, "_blank", "toolbar=no,scrollbars=yes,resizable=yes,top=500,left=500,width=650,height=250");
  return false; 
}
</script>

</asp:Panel>
