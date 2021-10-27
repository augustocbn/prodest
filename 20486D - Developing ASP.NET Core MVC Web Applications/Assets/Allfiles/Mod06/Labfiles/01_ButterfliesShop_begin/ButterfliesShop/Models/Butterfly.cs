using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesShop.Models
{
    public class Butterfly
    {
        public int Id { get; set; }

        [Display(Name = "Common Name:")]
        [Required(ErrorMessage = "Por favor, informe o nome")]
        public string CommonName { get; set; }

        [Display(Name = "Butterfly Family:")]
        [Required(ErrorMessage = "Por favor, informe a família")]
        public Family? ButterflyFamily { get; set; }

        [Display(Name = "Butterflies Quantity:")]
        [Required(ErrorMessage = "Por favor, informe a quantidade")]
        public int Quantity { get; set; }
    }
}
