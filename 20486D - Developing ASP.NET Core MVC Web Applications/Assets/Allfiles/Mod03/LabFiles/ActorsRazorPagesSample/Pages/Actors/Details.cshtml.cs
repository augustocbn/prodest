using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActorsRazorPagesSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ActorsRazorPagesSample.Pages.Actors
{
    public class DetailsModel : PageModel
    {
        private readonly IData _data = new Data();
        
        public Actor Actor { get; set; }

        public IActionResult OnGet(int? id)
        {
            _data.ActorsInitializeData();

            if (id == null)
                return NotFound();

            Actor = _data.GetActorById(id);

            return Page();
        }

    }
}
