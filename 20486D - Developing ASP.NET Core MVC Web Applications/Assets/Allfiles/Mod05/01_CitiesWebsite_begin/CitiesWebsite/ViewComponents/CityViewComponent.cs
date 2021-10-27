using CitiesWebsite.Models;
using CitiesWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesWebsite.ViewComponents
{
    public class CityViewComponent : ViewComponent
    {
        private readonly ICityProvider _cityProvider;

        public CityViewComponent(ICityProvider cityProvider)
        {
            _cityProvider = cityProvider;
        }

        //public async Task<IViewComponentResult> InvokeAsync(string cityName)
        //{
        //    ViewBag.City = _cityProvider[cityName];
        //    return View("SelectedCity");
        //}

        public async Task<IViewComponentResult> InvokeAsync(string cityName)
        {
            ViewBag.City = await Task.FromResult(_cityProvider[cityName]);
            return View("SelectedCity");
        }

    }
}
