using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Repository;

namespace TuljaBhavani_Theertham.Services
{
    public class PaymentService
    {
        private readonly PaymentRepository _paymentRepository;

        public PaymentService(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> ProcessPayment(Payment payment)
        {
            return await _paymentRepository.AddPayment(payment);
        }
    }
}
