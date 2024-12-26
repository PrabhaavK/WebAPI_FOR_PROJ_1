using System.Collections.Generic;
using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Repository;

namespace TuljaBhavani_Theertham.Services
{
    public class PoojaService
    {
        private readonly PoojaRepository _poojaRepository;

        public PoojaService(PoojaRepository poojaRepository)
        {
            _poojaRepository = poojaRepository;
        }

        public async Task<List<Pooja>> ListPoojas()
        {
            return await _poojaRepository.GetPoojas();
        }
    }
}
