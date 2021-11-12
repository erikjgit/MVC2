using MVC2.Models.Repo;
using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Service
{
    public class LanguageService : ILanguageService
    {
        ILanguageRepo languages;
        public LanguageService(ILanguageRepo languageRepo)
        {
            languages = languageRepo;
        }
        public Language Add(LanguageViewModel languageViewModel)
        {
            return (languages.Create(languageViewModel.Name));
        }

        public LanguageViewModel All()
        {
            LanguageViewModel l = new LanguageViewModel();
            l.LanguageList = languages.Read();
            if (l.LanguageList == null)
            {
                l.LanguageList = new List<Language>();
            }
            return (l);
        }

        public Language FindBy(int id)
        {
            return (languages.Read(id));
        }

        public bool Remove(int id)
        {
            return (languages.Delete(languages.Read(id)));
        }
    }
}
