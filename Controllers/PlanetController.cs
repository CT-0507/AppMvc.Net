using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    [Route("he-mat-troi/[action]")]
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }
        [Route("/danh-sach-cac-hanh-tinh.html")]
        public IActionResult Index()
        {
            return View();
        }
        // route: action
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name { get; set; }

        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Venus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Mars()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Jupiter()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Saturn()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Uranus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        // controller, action, area => [controller] [action] [area]
        // co the khai bao nhieu route
        [Route("[controller]/[action]", Name = "neptune1")]
        [Route("sao/[action]", Order = 1)]
        public IActionResult Neptune()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        [Route("hanh-tinh/{id:int}")]
        public IActionResult PlanetInfo(int id)
        {
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }
        // [Route]
        // [HttpGet("/abc.com")]
        // [HttpPatch]
        // [HttpDelete]
        // [HttpPost]
        // [HttpPut]
    }
}