using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);
        PeopleViewModel All();
        PeopleViewModel FindBy(PeopleViewModel search);
        Person FindBy(int id);
        Person Edit(int id, Person person);
        bool Remove(int id);
    }
}
