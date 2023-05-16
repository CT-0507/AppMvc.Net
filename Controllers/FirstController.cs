using System.IO;
using System.Linq;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;

        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public string Index()
        {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData
            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData
            return "Toi la index cua First";
        }
        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("Hi", "Hello");
        }

        public object Anything() => new
        {
            abc = 1,
        };

        public IActionResult Readme()
        {
            var content = @"
            Xin chao cac ban,
            cac ban dang hoc ve ASP.NET MVC

            Cuong
            ";
            return Content(content, "text/plain");
        }
        public FileContentResult Pic()
        {
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "ros.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/jpg");
        }

        public IActionResult IPhonePrice()
        {
            return Json(
                new
                {
                    ProductName = "Iphone",
                    Price = 1000,
                }
            );
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den " + url);
            return LocalRedirect(url); // local ~ host
        }

        public IActionResult Google()
        {
            return Redirect("https://google.com");
        }

        //ViewResult | View()
        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = "Khach";
            }
            // View() => Razor Engine, doc, cshtml (template)
            // View(template) - template duong dan tuyet doi toi .cshtml
            // View(template, model)

            // xinchao2.cshtml => /View/First/xinchao2.cshtml
            // return View("xinchao2");
            // return View("/MyView/xinchao1.cshtml", ("Cuong", 123));
            return View("Xinchao3", ("Cuong", 123));
        }
        [TempData]
        public string StatusMessage { set; get; }

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(c => c.Id == id).FirstOrDefault();
            if (product == null)
            {
                // TempData["StatusMessage"] = "San pham ban tim khong ton tai";
                StatusMessage = "San pham ban tim khong ton tai";
                return Redirect(Url.Action("Index", "Home"));
            }
            // return Content($"San pham ID = {id}");
            // truyen du lieu qua view
            // return View(product);
            //truyen du lieu qua viewdata
            // this.ViewData["product"] = product;
            // return View("ViewProduct2");

            // TempData["ThongBao"] luu vao session neu doc o trang khac thi sau lan dau se xoa luon

            ViewBag.product = product;
            return View("ViewProduct3");
        }
    }
}

// Kiểu trả về                 | Phương thức
//     ------------------------------------------------
//     ContentResult               | Content()
//     EmptyResult                 | new EmptyResult()
//     FileResult                  | File()
//     ForbidResult                | Forbid()
//     JsonResult                  | Json()
//     LocalRedirectResult         | LocalRedirect()
//     RedirectResult              | Redirect()
//     RedirectToActionResult      | RedirectToAction()
//     RedirectToPageResult        | RedirectToRoute()
//     RedirectToRouteResult       | RedirectToPage()
//     PartialViewResult           | PartialView()
//     ViewComponentResult         | ViewComponent()
//      StatusCodeResult            | StatusCode()
//     // ViewResult                  | View()