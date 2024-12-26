using System.Collections.Generic;
using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using Microsoft.EntityFrameworkCore;

namespace TuljaBhavani_Theertham.Repository
{
    public class PoojaRepository
    {
        private readonly AppDbContext _context;

        public PoojaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pooja>> GetPoojas()
        {
            return await _context.Poojas.ToListAsync();
        }
    }
}
