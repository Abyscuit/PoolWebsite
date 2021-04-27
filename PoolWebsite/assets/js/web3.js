<script>
function update(){
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
		if(this.readyState == 4 && this.status == 200) {
			var bal = this.responseText;
			document.getElementById("bnb-address").innerText = bal.split(":")[0];
		}
	};
	
	xhttp.open("GET", "bnb-bal", true);
	xhttp.send();
}
update();
</script>