<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Import Namespace="System.IO" %>

<script runat="server">

private string tilePath;
private List<int> imageSize;

private void Page_Load(object sender, System.EventArgs e)
{
	tilePath = Request.QueryString["path"];

	if (String.IsNullOrEmpty(tilePath))
	{
		Response.Redirect("default.aspx");
		return;
	}
	
	imageSize = File.ReadAllText(Path.Combine(Server.MapPath(tilePath), "image-info.txt"))
		.Split(';').Select(x => Int32.Parse(x)).ToList();
}
</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Zoomable Image</title>

	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" integrity="sha512-dTfge/zgoMYpP7QbHy4gWMEGsbsdZeCXz7irItjcC3sPUFtf0kuFbDz/ixG7ArTxmDjLXDmezHubeNikyKGVyQ==" crossorigin="anonymous">
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" integrity="sha384-aUGj/X2zp5rLCbBxumKTCw2Z50WgIr1vs/PFN4praOTvYXWlVyh2UtNUU0KAUhAX" crossorigin="anonymous">
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js" integrity="sha512-K1qjQ+NcF2TYO/eI3M6v8EiNYZfA95pQumfvcVrTHtwQVDG+aHRqLi/ETn2uB+1JqwYqVG3LIvdm9lj6imS/pQ==" crossorigin="anonymous"></script>

	<link rel="stylesheet" href="http://cdn.leafletjs.com/leaflet-0.7.3/leaflet.css" />
	<script src="http://cdn.leafletjs.com/leaflet-0.7.3/leaflet.js"></script>
	<script type="text/javascript" src="ZoomableImage.js"></script>
</head>
<body>
	<div class="container">
		<h1>Zoomable Image <small>powered by Graphics Mill</small></h1>

		<a class="btn btn-primary" href="default.aspx">Upload another image</a>
		
		<br /><br />

		<div id="photo" style="width:600px;height:400px;"></div>

		<script type="text/javascript">
    		var map = L.map('photo', {
    			crs: L.CRS.Simple
    		}).setView(new L.LatLng(0, 0), 0);

			L.tileLayer.zoomableImage('<%=tilePath%>/{z}-{x}-{y}.jpg', {
				width: <%=imageSize[0]%>,
				height: <%=imageSize[1]%>,
    			tolerance: 0.8,
    			tileSize: 256,
    			attribution: '<a href="http://www.graphicsmill.com/">Graphics Mill</a>'
    		}).addTo(map);
		</script>
	</div>
</body>
</html>
