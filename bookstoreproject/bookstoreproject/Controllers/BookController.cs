using bookstoreproject.Models;
using bookstoreproject.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bookstoreproject.Controllers
{
    public class BookController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _LanguageRepository = null;
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        

        public BookController(BookRepository BookRepository, LanguageRepository LanguageRepository, IWebHostEnvironment IWebHostEnvironment) // constructor
        {
            _bookRepository =  BookRepository;
            _LanguageRepository = LanguageRepository;
            _IWebHostEnvironment = IWebHostEnvironment;
        }

        public async Task<ViewResult> GetAllBooks()
        {
             var data = await _bookRepository.GetAllBooks();

            return View(data);
        }

        public async Task<ViewResult> GetBook(int id,string bookName)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName , string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false,int BookId = 0)
        {
            var model = new BookModel()
            {
                LanguageId = 2
            };

            ViewBag.language = new SelectList(await _LanguageRepository.GetLanguages(),"Id","Name");

             ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = BookId;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookmodel)
        {
            if (ModelState.IsValid)
            {

                // image uload logic coverimage
                if(bookmodel.CoverPhoto != null)
                {
                   string folder = "books/cover";
                   bookmodel.CoverImageUrl = await UploadImage(folder,bookmodel.CoverPhoto);
                }

                // image uload logic galleryimage / multiple
                if (bookmodel.CoverPhoto != null)
                {
                    string folder = "books/cover";
                    bookmodel.CoverImageUrl = await UploadImage(folder, bookmodel.CoverPhoto);
                }


                int id = await _bookRepository.AddNewBook(bookmodel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, BookId = id });
                }
               
            }

            ViewBag.language = new SelectList(await _LanguageRepository.GetLanguages(), "Id", "Name");

            ModelState.AddModelError("", "The custom error message (A field has error)");

            return View();

        }

      
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            
            string severFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(severFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
