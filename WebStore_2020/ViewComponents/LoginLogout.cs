using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore_2020.ViewComponents
{
    public class LoginLogout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
