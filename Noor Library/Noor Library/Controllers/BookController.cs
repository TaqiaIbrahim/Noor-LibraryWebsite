using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Noor_Library.Data;
using Noor_Library.ViewModel;

namespace Noor_Library.Controllers
{
    public class BookController:Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var viewModel = new ViewModelForm
            {
                categories = _context.Categories.ToList(),
                books = _context.books.ToList(),
                authors = _context.Authors.ToList(),
            };
            return View(viewModel);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var book = _context.books.Include(m => m.Author).Include(c=>c.Category).SingleOrDefault(m => m.Id == id);
            if (book == null)
                return NotFound();
            var viewModel = new BookViewModel
            {
                 Id=book.Id,
                Author=book.Author,
                Title=book.Title,
                Description=book.Description,
                Cover=book.Cover,
                Category=book.Category,
                Pdf=book.Pdf,
             
            };
            return View(viewModel);
        }
        public IActionResult Download(int id)
        {
            var book = _context.books.Find(id);
            if(book == null||string.IsNullOrEmpty(book.Pdf))
                return NotFound();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/Books", book.Pdf);
            var fileByte=System.IO.File.ReadAllBytes(filePath);
            return File(fileByte, "application/pdf", book.Title + ".pdf");
        
        }
        public IActionResult Read(int id) 
        {
            var book=_context.books.Find(id);
            if(book==null||string.IsNullOrEmpty(book.Pdf)) return NotFound();
            var fileUrl = "/uploads/Books/" + book.Pdf;
            return View("Read", fileUrl);
        }
        
     
        
    }
}
