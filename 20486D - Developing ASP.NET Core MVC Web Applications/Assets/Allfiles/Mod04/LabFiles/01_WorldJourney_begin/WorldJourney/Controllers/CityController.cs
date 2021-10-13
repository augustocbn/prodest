using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorldJourney.Models;

namespace WorldJourney.Controllers
{
    public class CityController : Controller
    {
        private readonly IData _data;
        private readonly IWebHostEnvironment _environment;

        public CityController(IData data, IWebHostEnvironment environment)
        {
            _data = data;
            _environment = environment;
            _data.CityInitializeData();
        }

        public IActionResult Index()
        {
            ViewData["Page"] = "Search City";
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewData["Page"] = "Selected City";

            var city = _data.GetCityById(id);

            if (city == null)
            {
                return NotFound();
            }

            ViewBag.Title = city.CityName;

            return View(city);
        }

        public IActionResult GetImage(int cityId)
        {
            var city = _data.GetCityById(cityId);
            var rootPath = _environment.WebRootPath;
            var folderPath = "\\images\\";
            var fullPath = rootPath + folderPath + city.ImageName;

            var stream = new FileStream(fullPath, FileMode.Open);
            byte[] image;

            using(var reader = new BinaryReader(stream))
            {
                image = reader.ReadBytes((int)stream.Length);
            }

            return File(image, city.ImageMimeType);
        }
    }
}
