using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Service
{
    public interface ICityService
    {
        City Add(CityViewModel cityViewModel);
        CityViewModel All();
        City FindBy(int id);
        bool Remove(int id);
    }
}
