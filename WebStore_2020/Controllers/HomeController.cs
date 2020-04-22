using Microsoft.AspNetCore.Mvc;
using WebStore_2020.Infrastructure;

namespace WebStore_2020.Controllers
{
    [SampleActionFilter]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //throw new ApplicationException("Ошибочка вышла...");
            return View();
        }
                
        // GET: /<controller>/blog
        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ProductDetails()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }
    }
}