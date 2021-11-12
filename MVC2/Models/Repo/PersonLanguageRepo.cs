using MVC2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public class PersonLanguageRepo : IPersonLanguageRepo
    {
        private readonly PeopleDbContext _dbContext;
        public PersonLanguageRepo(PeopleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public PersonLanguage Create(Person person, Language language)
        {
            //PersonLanguage pl = new PersonLanguage(person, language);
            PersonLanguage pl = new PersonLanguage();
            pl.PersonId = person.Id;
            pl.LanguageId = language.Id;
            _dbContext.PersonLanguages.Add(pl);
            _dbContext.SaveChanges();
            return (pl);
        }

        public List<PersonLanguage> Read(Person person)
        {
            throw new NotImplementedException();
        }

        public List<PersonLanguage> Read(Language language)
        {
            throw new NotImplementedException();
        }
        public PersonLanguage Read(Person person, Language language)
        {
            return _dbContext.PersonLanguages.SingleOrDefault(pl => pl.PersonId == person.Id && pl.LanguageId == language.Id);
        }
        
        public List<PersonLanguage> Read()
        {
            return (_dbContext.PersonLanguages.ToList());
        }

        public bool Delete(Person person, Language language)
        {
            PersonLanguage pl = Read(person, language);
            if (pl == null)
            {
                return false;
            }
            _dbContext.PersonLanguages.Remove(pl);
            _dbContext.SaveChanges();
            return true;

        }
    }
}
