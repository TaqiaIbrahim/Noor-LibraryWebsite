using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Noor_Library.Data;
using Noor_Library.Models;
using Noor_Library.ViewModel;

namespace Noor_Library.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.books.Include(b=>b.Author).Include(c=>c.Category).ToList());
        }
        public IActionResult AddOrEdit(int id)
        {

            var viewModel = new ViewModelForm
            {
                categories = _context.Categories.ToList(),

                authors = _context.Authors.ToList()

            };
            ViewBag.categories = viewModel.categories.ToList();
            ViewBag.Authors = viewModel.authors.ToList();

            if (id == 0)
            {
                return View(new Book());
            }
            else
                return View(_context.books.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(List<IFormFile> pdfFile, List<IFormFile> coverFile, Book book) 
        {
            foreach (var file in coverFile)
            {
                if (file.Length > 0)
                {
                    var ext = Path.GetExtension(file.FileName);
                    string Cover = Guid.NewGuid().ToString() + ext;
                    var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\Covers", Cover);
                    using (var stream = System.IO.File.Create(FilePaths))
                    {
                        await file.CopyToAsync(stream);
                    }
                    book.Cover = Cover;
                }
            }
            foreach (var file in pdfFile)
            {
                if (file.Length > 0)
                {
                    string Pdf = Guid.NewGuid().ToString() + ".pdf";
                    var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\Books", Pdf);
                    using (var stream = System.IO.File.Create(FilePaths))
                    {
                        await file.CopyToAsync(stream);
                    }
                    book.Pdf = Pdf;
                }

            }


            if (book.Id == 0)
                _context.books.Add(book);
            else
                _context.books.Update(book);
            _context.SaveChanges();
            return RedirectToAction("Index");

            
            
        }
        public async Task<IActionResult> Delete(int id)
        {
            var book = _context.books.Find(id);
                _context.books.Remove(book);
                await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
                    
            
        }
    }
}
