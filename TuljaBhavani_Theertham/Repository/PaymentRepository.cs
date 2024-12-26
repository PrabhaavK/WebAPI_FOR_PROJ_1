using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using Microsoft.EntityFrameworkCore;

namespace TuljaBhavani_Theertham.Repository
{
    public class PaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
