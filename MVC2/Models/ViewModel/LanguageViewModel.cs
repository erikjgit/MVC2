using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.ViewModel
{
    public class LanguageViewModel
    {
        public LanguageViewModel()
        {
            LanguageList = new List<Language>();
        }
        public List<Language> LanguageList { get; set; } 
        public string Name { get; set; }
    }
}
