using bookstoreproject.Data;
using bookstoreproject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstoreproject.Repository
{
    public class LanguageRepository
    {

        private readonly BookStoreContext _context = null;

        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.languages.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

            }).ToListAsync();
        }

    }
}
