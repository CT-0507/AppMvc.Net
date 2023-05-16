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