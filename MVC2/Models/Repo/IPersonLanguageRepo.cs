using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public interface IPersonLanguageRepo
    {
        List<PersonLanguage> Read();
        PersonLanguage Create(Person person, Language language);
        bool Delete(Person person, Language language);
        List<PersonLanguage> Read(Person person);
        List<PersonLanguage> Read(Language language);
        public PersonLanguage Read(Person person, Language language);
    }
}
