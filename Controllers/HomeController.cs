using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTestVersta.Models;

namespace WebTestVersta.Controllers
{
    public class HomeController : Controller
    {

        private SuppliesDbContext db;

        public HomeController(SuppliesDbContext supplies) 
        {
            db = supplies;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}