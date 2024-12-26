using System.Collections.Generic;
using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using Microsoft.EntityFrameworkCore;

namespace TuljaBhavani_Theertham.Repository
{
    public class PoojariRepository
    {
        private readonly AppDbContext _context;

        public PoojariRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Poojari>> GetPoojaris()
        {
            return await _context.Poojaris.ToListAsync();
        }

        public async Task<bool> AddFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
