using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspSonatelRH.Models;

namespace AspSonatelRH.Controllers
{
    public class HomeController : Controller
    {
        RHDbContext db = new RHDbContext();
        public IActionResult Index()
        {
            // var list = db.Candidat.Select(x => x.NomCandidat).ToList();
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
