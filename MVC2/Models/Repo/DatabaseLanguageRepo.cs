using MVC2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public class DatabaseLanguageRepo : ILanguageRepo
    {
        private readonly PeopleDbContext _dbContext;
        public DatabaseLanguageRepo(PeopleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Language Create(string name)
        {
            Language l = new Language();
            l.Name = name;
            _dbContext.Languages.Add(l);
            _dbContext.SaveChanges();
            return l;
        }

        public bool Delete(Language language)
        {
            if (_dbContext.Languages.Find(language.Id) == null)
            {
                return false;
            }
            _dbContext.Languages.Remove(language);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Language> Read()
        {
            return (_dbContext.Languages.ToList());
        }

        public Language Read(int id)
        {
            Language l = _dbContext.Languages.Find(id);
            if (l == null)
            {
                return (new Language());
            }
            return l;
        }
    }
}
