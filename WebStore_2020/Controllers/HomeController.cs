using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore_2020.Models;

namespace WebStore_2020.Controllers
{
    public class HomeController : Controller
    {
        List<EmployeeViewModel> _employees = new List<EmployeeViewModel>
        {
            new EmployeeViewModel
            {
                Id = 1,
                FirstName = "Иван",
                SurName = "Иванов",
                Patronymic = "Иванович",
                Age = 22,
                Position = "Начальник"
            },

            new EmployeeViewModel
            {
                Id = 2,
                FirstName = "Петр",
                SurName = "Петров",
                Patronymic = "Петрович",
                Age = 35,
                Position = "Программист"
            }
        };

        public IActionResult Index()
        {
            //return Content("Hello from home controller");
            return View(_employees);
        }
    }
}