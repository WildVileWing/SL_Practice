using SolarLab_Practice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolarLab_Practice.Interfaces {
    public interface IPersons{  
        IEnumerable<Person> Persons { get; }
        IEnumerable<Person> GetActualBirthDays { get; }
        Task<Person> GetObjectPerson(int personId);
        Task<Person> UpdateAsync(int id, Person newPerson);
    }
}
