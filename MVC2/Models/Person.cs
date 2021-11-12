using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models
{
    public class Person
    {
        [Required]
        public string Name { get; set; }
        public City City { get; set; }
        [Required]
        public int Phone { get; set; }
        [Key]
        public int Id { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }

        //public Person(string name, string city, int phone)
        //{

        //}

    }
}
