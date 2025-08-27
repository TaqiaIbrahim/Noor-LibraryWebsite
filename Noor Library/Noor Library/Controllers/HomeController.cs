using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Noor_Library.Data;
using Noor_Library.Models;
using Noor_Library.ViewModel;
using System.Diagnostics;

namespace Noor_Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var ViewModel = new ViewModelForm
            {
                
                Sliders = _context.Sliders.ToList(),
                authors = _context.Authors.ToList(),
                books = _context.books.ToList(),
                categories= _context.Categories.ToList(),
                
            };


            return View(ViewModel);
            
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