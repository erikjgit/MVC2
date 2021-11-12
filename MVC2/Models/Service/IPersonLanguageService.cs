using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Service
{
    public interface IPersonLanguageService
    {
        PersonLanguage Add(Person person, Language language);
        bool Remove(Person person, Language language);
        List<PersonLanguage> FindBy(Person person);
        List<PersonLanguage> FindBy(Language language);
    }
}
