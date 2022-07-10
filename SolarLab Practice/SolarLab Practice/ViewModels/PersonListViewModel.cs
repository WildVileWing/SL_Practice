using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolarLab_Practice.Models;

namespace SolarLab_Practice.ViewModels{
    public class PersonListViewModel{
        public IEnumerable<Person> AllPersons { get; set; }
        public DateTime BirthDayDate { get; set; }
    }
}
