using System.Collections.Generic;
using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Repository;

namespace TuljaBhavani_Theertham.Services
{
    public class PoojariService
    {
        private readonly PoojariRepository _poojariRepository;

        public PoojariService(PoojariRepository poojariRepository)
        {
            _poojariRepository = poojariRepository;
        }

        public async Task<List<Poojari>> ListPoojaris()
        {
            return await _poojariRepository.GetPoojaris();
        }

        public async Task<bool> SubmitFeedback(Feedback feedback)
        {
            return await _poojariRepository.AddFeedback(feedback);
        }
    }
}
