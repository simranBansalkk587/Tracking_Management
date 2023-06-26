using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking_Task.Data;
using Tracking_Task.Models;

namespace Tracking_Task.IRepository.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext _context;
        public BooksRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task AddBooks(Books books)
        {
            await _context.Books.AddAsync(books);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteBook(int Id)
        {
            var bookindb = await _context.Books.FindAsync(Id);
            _context.Books.Remove(bookindb);
            _context.SaveChanges();

        }

        public async Task<List<Books>> GetAll()
        {
            return _context.Books.ToList();
        }

        public async Task<Books> GetbyId(int Id)
        {
            return await _context.Books.FindAsync(Id);
        }


        public async Task UpdateBooks(Books Book)
        {
            _context.Books.Update(Book);
            await _context.SaveChangesAsync();
        }
    }
}
