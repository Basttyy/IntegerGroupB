<!DOCTYPE html>
<html>
<head>
	<title>Welcome to Drug Assure</title>
	<meta charset="utf-8">
	<meta name="ROBOTS" content="NOINDEX, NOFOLLOW" />
	<link rel="stylesheet" type="text/css" href="bootstrap.min.css">
	<link rel="stylesheet" href="easy-autocomplete.min.css"> 
	<link rel="stylesheet" type="text/css" href="med.css">
</head>
<body>
	<header>
		<div class="container">
		<div id="brand">
		<img src="drugassure.png">
		</div>	
		</div>
	</header>
	<div id="menu">
    <ul>
        <li><a href="med.html"> HOME</a></li>
        <li><a href="med4.html">DRUGS A-Z</a></li>
    </ul>
</div>

	<section id="main">
	<div class="container">
		<marquee behavior="slide" direction="left">
		<p>YOU ARE WELCOME TO</p>
		<h2>DRUG ASSURE</h2>	
		</marquee>
	</div>
		<div id="tfheader">
		<form id="tfnewsearch" method="post" action="">
		        <div align="center" class="form-group">
		        <input type="text" id="drug_search" name="search" class="form-control"  placeholder="Search...">
		        	
		        </div>
		</form>
	<div class="tfclear"></div>
	</div>
	</section>
	<section id="body">
	<div class="container">
	<p>Drug Assure is the most popular, comprehensive and up-to-date source of drug information online. Providing free, peer-reviewed, accurate and independent data on more than 100 prescription drugs, over-the-counter medicines & natural products.</p>
		<p>COMMON DRUGS</p>
		<p><a href= ""> Flagyl </a>
		<p><a href= ""> Ibuprofen </a>
		<p><a href= ""> Lipitor </a>
		<p><a href= ""> Protonix </a>
	</div>
	</section>

<footer>
	<p>Group B, Copyright &copy; 2017</p>
	<p>All rights reserved.</p>
</footer>
<script type="text/javascript" src='jquery.js'></script>
<script src="jquery.easy-autocomplete.min.js"></script> 
<script>
	
 $(document).ready(function(){
    // $.get('getDrugs.php',null,function(resp){
    // 	console.log(resp);
    // })
    var options = {
	url: function(phrase) {
		return "getDrugs.php?phrase=" + phrase + "&format=json";
	},
	getValue: "name",
	list: {
		maxNumberOfElements: 100,
		match: {
			enabled: true
		},
		onChooseEvent: function() {
			var selectedItem= $(".easy-autocomplete").find("ul li.selected");
            var value=selectedItem.text();
            window.location.href='med2.html?name='+value;

		}
	}
};

$("#drug_search").easyAutocomplete(options);
		
 })


</script>
</body>
</html>