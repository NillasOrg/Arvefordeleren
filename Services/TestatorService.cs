using Arvefordeleren.Models;
using Arvefordeleren.Models.Repositories;

namespace Arvefordeleren.Services
{
    public class TestatorService
    {
        private readonly TestatorRepository _testatorRepository;

        public TestatorService(TestatorRepository testatorRepository)
        {
            _testatorRepository = testatorRepository;
        }

        public async Task EstablishRelationToHeirAsync(Heir heir, int? selectedTestatorId)
        {
            if (!selectedTestatorId.HasValue)
                return;
            
            var testator = _testatorRepository.GetTestatorById(selectedTestatorId.Value);
            if (testator != null && !testator.Heirs.Any(h => h.Id == heir.Id))
            {
                testator.Heirs.Add(heir);

                await _testatorRepository.SaveChangesAsync();
            }
        }
    }
}