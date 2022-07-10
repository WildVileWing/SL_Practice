using Microsoft.AspNetCore.Mvc;
using SolarLab_Practice.Interfaces;
using SolarLab_Practice.Models;
using SolarLab_Practice.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace SolarLab_Practice.Controllers {
    public class PersonController : Controller{
        private readonly IPersons _allPersons;
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PersonController(IPersons iPersonBirthDay, AppDBContext database, IWebHostEnvironment hostEnvironment){
            _allPersons = iPersonBirthDay;
            _context = database;
            _hostEnvironment = hostEnvironment;
        }
    
        public ViewResult List(){
            ViewBag.Title = "Birthdays";
            PersonListViewModel obj = new PersonListViewModel();
            obj.AllPersons = _allPersons.Persons;
            obj.BirthDayDate = DateTime.Now;
            return View(obj);
        }

        public ViewResult Actual() {
            ViewBag.Title = "Actual";  
            PersonListViewModel obj = new PersonListViewModel();
            obj.AllPersons = _allPersons.GetActualBirthDays;
            return View(obj);
        }

        [HttpGet]
        public IActionResult Add() {
            ViewBag.Title = "Add";
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("name, birthDay, imageFile")] Person person) {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            person.image = person.imageFile.FileName;
            string imagePath = Path.Combine(wwwRootPath + "/img", person.imageFile.FileName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create)) {
                await person.imageFile.CopyToAsync(fileStream);
            }
            _context.Add(person);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Edit(int id) {
            var person = await _allPersons.GetObjectPerson(id);
            if (person == null) return View("List");
            return View(person);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Person person) {
            if (!ModelState.IsValid)
                return View(person);
            if(person.image == null) {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                person.image = person.imageFile.FileName;
                string imagePath = Path.Combine(wwwRootPath + "/img", person.imageFile.FileName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create)) {
                    await person.imageFile.CopyToAsync(fileStream);
                }
            }
            await _allPersons.UpdateAsync(id, person);
            return RedirectToAction("List");
        }
        
        public IActionResult Delete(int id) {
            Person person = new Person() { id = id };
            _context.Attach(person);
            _context.Remove(person);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
