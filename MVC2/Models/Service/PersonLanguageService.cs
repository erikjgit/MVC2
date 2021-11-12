using MVC2.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Service
{
    public class PersonLanguageService : IPersonLanguageService
    {
        IPersonLanguageRepo personLanguages;
        public PersonLanguageService(IPersonLanguageRepo personLanguageRepo)
        {
            personLanguages = personLanguageRepo;
        }
        public PersonLanguage Add(Person person, Language language)
        {
            return (personLanguages.Create(person, language));
        }

        public List<PersonLanguage> FindBy(Person person)
        {
            IEnumerable<PersonLanguage> plQuery =
                from PersonLanguage pl in personLanguages.Read()
                where pl.PersonId == person.Id
                select pl;
            if(plQuery == null)
            {
                return new List<PersonLanguage>();
            }
            return (plQuery.ToList());
        }

        public List<PersonLanguage> FindBy(Language language)
        {
            IEnumerable<PersonLanguage> plQuery =
                from PersonLanguage pl in personLanguages.Read()
                where pl.LanguageId == language.Id
                select pl;
            if (plQuery == null)
            {
                return new List<PersonLanguage>();
            }
            return (plQuery.ToList());
        }

        public bool Remove(Person person, Language language)
        {
            return (personLanguages.Delete(person, language));
        }
    }
}
