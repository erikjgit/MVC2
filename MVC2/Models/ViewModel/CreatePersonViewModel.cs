using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.ViewModel
{
    public class CreatePersonViewModel
    {
        [Required]
        public string Name { get; set; }
        public City City { get; set; }
        public int Phone { get; set; }

        public CreatePersonViewModel()
        {

        }
    }
}
