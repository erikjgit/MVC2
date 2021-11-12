using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Service
{
    public interface ILanguageService
    {
        Language Add(LanguageViewModel languageViewModel);
        LanguageViewModel All();
        Language FindBy(int id);
        bool Remove(int id);

    }
}
