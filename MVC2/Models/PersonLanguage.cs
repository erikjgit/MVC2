using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models
{
    public class PersonLanguage
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
        //public PersonLanguage(Person person, Language language)
        //{
        //    PersonId = person.Id;
        //    Person = person;
        //    LanguageId = language.Id;
        //    Language = language;
        //}
    }
}
