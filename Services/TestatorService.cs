using Arvefordeleren.Models;
using Arvefordeleren.Models.Repositories;

namespace Arvefordeleren.Services
{
    public class TestatorService
    {
        private readonly TestatorRepository _testatorRepository;

        public TestatorService(TestatorRepository repository)
        {
            _testatorRepository = repository;
        }
        public void EstablishRelationToHeir(Heir heir, int? selectedTestatorId)
        {
            if (selectedTestatorId.HasValue)
            {
                var newTestator = _testatorRepository.testators.FirstOrDefault(t => t.Id == selectedTestatorId);

                if (newTestator != null && !newTestator.Heirs.Any(h => h.Id == heir.Id))
                {
                    newTestator.Heirs.Add(heir);
                }
            }
        }
    }
}
