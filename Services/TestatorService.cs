using Arvefordeleren.Models;
using Arvefordeleren.Models.Repositories;

namespace Arvefordeleren.Services
{
    public class TestatorService
    {
        public void EstablishRelationToHeir(Heir heir, int? selectedTestatorId)
        {
            foreach (var oldTestator in TestatorRepository.testators)
            {
                if (oldTestator.Heirs.Any(h => h.Id == heir.Id))
                {
                    oldTestator.Heirs.Remove(heir);
                }
            }

            if (heir.TypeOfChild == TypeOfChild.Fællesbarn)
            {
                foreach (var testator in TestatorRepository.testators)
                {
                    if (!testator.Heirs.Any(h => h.Id == heir.Id))
                    {
                        testator.Heirs.Add(heir);
                    }
                }
            }
            else if (selectedTestatorId.HasValue)
            {
                var newTestator = TestatorRepository.testators.FirstOrDefault(t => t.Id == selectedTestatorId);

                if (newTestator != null && !newTestator.Heirs.Any(h => h.Id == heir.Id))
                {
                    newTestator.Heirs.Add(heir);
                }
            }
        }
    }
}
