using SolarLab_Practice.Models;
using System;
using System.Linq;

namespace SolarLab_Practice.Data {
    public class DBObjects {
        public static void Initial(AppDBContext appDBContext) {
            if (!appDBContext.Person.Any()) {
                appDBContext.AddRange(
                    new Person {name = "Andrey", birthDay = new DateTime(2002, 7, 05), image = "person1.png" },
                    new Person {name = "Billy", birthDay = new DateTime(1969, 7, 14), image = "person2.png" },
                    new Person {name = "Oleg", birthDay = new DateTime(2004, 8, 22), image = "person3.png" },
                    new Person {name = "Luke", birthDay = new DateTime(2000, 6, 1), image = "person4.png" }
                );
            }
            appDBContext.SaveChanges();
        }
    }
}
