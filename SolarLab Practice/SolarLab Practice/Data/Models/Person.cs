using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarLab_Practice.Models {
    public class Person{
        public int id { get; set;  }
        public string name { get; set; }
        public DateTime birthDay { get; set; }
        public string image { get; set; }

        [NotMapped]
        public IFormFile imageFile { get; set; }


    }
}
