<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Import Namespace="System.IO" %>

<script runat="server">

private const string uploadPath = "~/Upload/";

private string errorMessage;

private void Page_Load(object sender, System.EventArgs e) 
{
	var uploadedFile = Request.Files["inputFile"];

	if (uploadedFile != null)
	{
		try
		{
			var tempSourcePath = Path.GetTempFileName();

			uploadedFile.SaveAs(tempSourcePath);

			var baseName = Guid.NewGuid().ToString();

			var tileGenerator = new ZoomableImage.ZoomableImageGenerator();
			tileGenerator.InputFilePath = tempSourcePath;
			tileGenerator.OutputDirPath = Path.Combine(Server.MapPath(uploadPath), baseName);
			tileGenerator.Generate();
			
			//Write width and height of image to text file
			using (var reader = Aurigma.GraphicsMill.Codecs.ImageReader.Create(tempSourcePath))
			{
				File.WriteAllText(Path.Combine(tileGenerator.OutputDirPath, "image-info.txt")
					, String.Format("{0};{1}", reader.Width, reader.Height));
			}
		}
		catch (Exception ex)
		{
			errorMessage = ex.Message;
		}
	}
}

</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Zoomable Image</title>

	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" integrity="sha512-dTfge/zgoMYpP7QbHy4gWMEGsbsdZeCXz7irItjcC3sPUFtf0kuFbDz/ixG7ArTxmDjLXDmezHubeNikyKGVyQ==" crossorigin="anonymous">
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" integrity="sha384-aUGj/X2zp5rLCbBxumKTCw2Z50WgIr1vs/PFN4praOTvYXWlVyh2UtNUU0KAUhAX" crossorigin="anonymous">
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js" integrity="sha512-K1qjQ+NcF2TYO/eI3M6v8EiNYZfA95pQumfvcVrTHtwQVDG+aHRqLi/ETn2uB+1JqwYqVG3LIvdm9lj6imS/pQ==" crossorigin="anonymous"></script>
</head>
<body>
	<div class="container">
		<h1>Zoomable Image <small>powered by Graphics Mill</small></h1>
		<h2>Upload new file</h2>

		<% if (!String.IsNullOrEmpty(errorMessage)) { %>
		<div class="alert alert-danger alert-dismissible fade in" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button>
				<h4>Error</h4>
				<p><%: errorMessage %></p>
		</div>
		<% } %>

		<form id="form1" runat="server" method="post" enctype="multipart/form-data" action=".">
			<div class="form-group">
				<label for="exampleInputFile">Image to cut into tiles</label>
				<input type="file" id="inputFile" name="inputFile">
				<p class="help-block">JPEG, PNG, TIFF, PSD</p>
			</div>
			<button type="submit" class="btn btn-default">Upload</button>
		</form>

		<h2>Uploaded files</h2>
		
		<ul>
			<% foreach (var dir in new DirectoryInfo(Server.MapPath(uploadPath)).GetDirectories()
				.OrderBy(x => x.CreationTime).ToList()) { %>
			<li><a href="view.aspx?path=<%=HttpUtility.UrlEncode(Page.ResolveUrl(uploadPath) + dir.Name)%>"><%: dir.Name %> (<%: String.Format("{0:f}", dir.CreationTime) %>)</a></li>
			<% } %>
		</ul>
	</div>
</body>
</html>
