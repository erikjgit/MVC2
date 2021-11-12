using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public interface ILanguageRepo
    {
        Language Create(string name);
        List<Language> Read();
        Language Read(int id);
        bool Delete(Language language);
    }
}
