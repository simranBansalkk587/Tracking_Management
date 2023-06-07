using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking_Task.Models;

namespace Tracking_Task.IRepository
{
    public interface IBooksRepository
    {
        Task<List<Books>> GetAll();
        Task<Books> GetbyId(int Id);
        Task AddBooks(Books books);
        Task UpdateBooks(Books Book);
        Task DeleteBook(int Id);
    }
}
