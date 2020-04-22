﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_2020.Infrastructure.Interfaces;
using WebStore_2020.Models;

namespace WebStore_2020.Infrastructure.Services
{
    public class InMemoryEmployeeService : IEmployeesService
    {
        List<EmployeeViewModel> _employees;

        public InMemoryEmployeeService()
        {
            _employees = new List<EmployeeViewModel>
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
        }

        public void AddNew(EmployeeViewModel model)
        {
            model.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(model);
        }

        public void Commit()
        {
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            EmployeeViewModel employee = GetById(id);
            if (employee is null)
                return;

            _employees.Remove(employee);
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return _employees;
        }

        public EmployeeViewModel GetById(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }
    }
}
