using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.ViewModel
{
    public class CreatePersonViewModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }

        public CreatePersonViewModel()
        {

        }
    }
}
