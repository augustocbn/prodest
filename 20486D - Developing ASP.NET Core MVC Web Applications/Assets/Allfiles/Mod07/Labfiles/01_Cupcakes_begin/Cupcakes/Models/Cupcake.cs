using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cupcakes.Models
{
    public class Cupcake
    {
        [Key]
        public int CupcakeId { get; set; }

        [Required(ErrorMessage = "Selecione o tipo do cupcake")]
        [Display(Name = "Cupcake Type:")]
        public CupcakeType? CupcakeType { get; set; }

        [Required(ErrorMessage = "Informe a descrição")]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Display(Name = "Gluten Free:")]
        public bool GlutenFree { get; set; }

        [Display(Name = "Caloric Value:")]
        public int CaloricValue { get; set; }

        [Range(1, 15)]
        [Required(ErrorMessage = "Informe o preço do cupcake")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price:")]
        public double Price { get; set; }

        [NotMapped]
        [Display(Name = "Cupcake Picture")]
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        [Required(ErrorMessage = "Selecione a Bakery")]
        public int? BakeryId { get; set; }

        public virtual Bakery Bakery { get; set; }
    }
}
