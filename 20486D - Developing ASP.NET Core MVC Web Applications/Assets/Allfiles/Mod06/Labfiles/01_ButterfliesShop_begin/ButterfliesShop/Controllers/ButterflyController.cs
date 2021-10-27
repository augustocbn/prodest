using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterfliesShop.Models;
using ButterfliesShop.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ButterfliesShop.Controllers
{
    public class ButterflyController : Controller
    {
        private IDataService _data;
        private IWebHostEnvironment _environment;
        private IButterfliesQuantityService _butterfliesQuantityService;

        public ButterflyController(IDataService data, IWebHostEnvironment environment, IButterfliesQuantityService butterfliesQuantityService)
        {
            _data = data;
            _environment = environment;
            _butterfliesQuantityService = butterfliesQuantityService;
            InitializeButterfliesData();
        }

        private void InitializeButterfliesData()
        {
            if (_data.ButterfliesList == null)
            {
                List<Butterfly> butterflies = _data.ButterfliesInitializeData();
                foreach (var butterfly in butterflies)
                {
                    _butterfliesQuantityService.AddButterfliesQuantityData(butterfly);
                }
            }
        }

        public IActionResult GetImage(int id)
        {
            Butterfly requestedButterfly = _data.GetButterflyById(id);
            if (requestedButterfly != null)
            {
                return null;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(Butterfly butterfly)
        {
            if (ModelState.IsValid)
            {
                butterfly.Id = _data.ButterfliesList.LastOrDefault().Id + 1;
                _data.AddButterfly(butterfly);

                return RedirectToAction("Index");
            }

            return View(butterfly);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var indexViewModel = new IndexViewModel
            {
                Butterflies = _data.ButterfliesList
            };

            return View(indexViewModel);
        }
    }
}