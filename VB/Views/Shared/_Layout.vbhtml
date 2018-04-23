<!DOCTYPE html>

<html>
<head>
    <title>@ViewBag.Title</title>
    @Html.DevExpress().GetStyleSheets(
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView})
@Html.DevExpress().GetScripts( 
    new Script  With { .ExtensionSuite = ExtensionSuite.GridView })
</head>

<body>
	@RenderBody()
</body>
</html>