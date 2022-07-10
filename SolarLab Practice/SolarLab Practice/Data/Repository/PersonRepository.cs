using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolarLab_Practice.Interfaces;
using SolarLab_Practice.Models;

namespace SolarLab_Practice.Repository {
    public class PersonRepository : IPersons {

        private readonly AppDBContext appDBContext;

        public PersonRepository(AppDBContext _appDBContent) {
            appDBContext = _appDBContent;
        }

        public IEnumerable<Person> Persons => appDBContext.Person;

        public IEnumerable<Person> GetActualBirthDays =>appDBContext.Person.Where(p => 
                ((p.birthDay.Date.Day >= DateTime.Now.Date.Day) && (p.birthDay.Date.Day <= DateTime.Now.Date.Day + 15)) 
                && (p.birthDay.Date.Month >= (DateTime.Now.Date.Month) && (p.birthDay.Date.Month <= DateTime.Now.Date.Month + 1)));

        public async Task<Person> GetObjectPerson(int personId) => appDBContext.Person.FirstOrDefault(p => p.id == personId);

        public async Task<Person> UpdateAsync(int id, Person newPerson) {
            appDBContext.Update(newPerson);
            newPerson.image = newPerson.imageFile.FileName;
            await appDBContext.SaveChangesAsync();
            return newPerson;
        }


    }
}
