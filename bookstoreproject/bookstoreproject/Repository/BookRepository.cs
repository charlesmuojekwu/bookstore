
using bookstoreproject.Data;
using bookstoreproject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstoreproject.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context; 
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl

            };

            await _context.books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;

           
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.books
                .Select(book => new BookModel()
                    {                   
                        Title = book.Title,
                        Author = book.Author,
                        Description = book.Description,
                        Id = book.Id,
                        LanguageId = book.LanguageId,
                        Language = book.Language.Name,
                        TotalPages = book.TotalPages,
                        Category = book.Category,
                        CoverImageUrl = book.CoverImageUrl,
                    }).ToListAsync();

        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    TotalPages = book.TotalPages,
                    Category = book.Category,
                    CoverImageUrl= book.CoverImageUrl
                }).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBook(string title , string authorname )
        {
            return null;
        }


    }
}
