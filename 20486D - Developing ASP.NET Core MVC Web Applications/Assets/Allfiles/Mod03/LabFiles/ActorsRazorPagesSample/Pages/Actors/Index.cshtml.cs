using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActorsRazorPagesSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ActorsRazorPagesSample.Pages.Actors
{
    public class IndexModel : PageModel
    {
        private readonly IData _data = new Data();

        public IList<Actor> Actors { get; set; }

        public void OnGet()
        {
            Actors = _data.ActorsInitializeData();
        }
    }
}
