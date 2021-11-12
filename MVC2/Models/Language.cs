using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }    
    }
}
