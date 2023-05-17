## Controller
- Là một lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc.Controller
- Action trong controller la mot phuong thuc public (khong duoc static)
- Action tra ve bat ky kieu du lieu nao, thuong la IACtionResult
- Cac dich vu inject vao controller qua ham tao

## View
- la file .cshtml
- View cho Action luu tai: /View/ControllerName/ActionName.cshtml
- Them thu muc luu tru View:

// {0} -> Ten Action
// {1} -> Ten Controller
// {2} -> Ten Area
options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension)

## Truyen du lieu sang View
- Model
- ViewData
- ViewBag
- TempData

## Areas
- La ten dung de routing
- La cau truc thu muc chua M.V.C
- Thiet lap Area cho controller bang ```[Area("AreaName")]```
- Tao cau truc thu muc

...
dotnet asp-codegenerator area Product

## Route
- endpoints.MapControllerRoute
- endpoints.MapAreaControllerRoute
- [AccepVerbs("POST", "GET")]
- [Route("pattern:)]
- [HttpGet] [HttpPost]

## Url Generation
### UrlHelper : Action, ActionLink, RouteUrl, Link
...
Url.Action("PlanetInfo", "Planet", new {id = 3}, Context.Request.Scheme)

Url.RouteUrl("default", new {controller = "First", action = "HelloView", id = 1, username = "Cuong"})
...
### HtmlTagHelper: ```<a> <button> <form>```
Su dung thuoc tinh
...
asp-area="Area"
asp-action="Action"
asp-controller="Controller"
asp-route...="123"
asp-route="default"