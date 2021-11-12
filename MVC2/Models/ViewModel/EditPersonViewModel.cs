using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.ViewModel
{
    public class EditPersonViewModel
    {
        
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }

        public List<Language> NotSpokenLaguages { get; set; } 
        public int AddId { get; set; }
        public int RemoveId { get; set; }
    }
}
