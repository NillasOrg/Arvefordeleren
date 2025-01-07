using Arvefordeleren.Services;

namespace Arvefordeleren.Models.Repositories
{
    public class TestatorRepository
    {
        private TestatorService testatorService;

        public TestatorRepository(TestatorService _testatorService)
        {
            testatorService = _testatorService;
        }

        public List<Testator> testators { get; set; } = new List<Testator>();

        public List<Person> ForcedHeirs => Shared.SharedData.ForcedHeirs;

        public void AddTestatorToForcedHeirs(Testator testator)
        {

            if (!ForcedHeirs.OfType<Testator>().Any(t => t.Id == testator.Id))
            {
                if (testator.Id == 2)
                {
                    ForcedHeirs.Add(testator);
                }
            }

        }

        public void AddNewTestator(Testator testator)
        {
            int maxId = testators.Any() ? testators.Max(t => t.Id) : 0; // Hvis listen er tom, start med ID 1            
            testators.Add(testator);
        }

        public async void AddAllTestator()
        {
            if (testators.Count > 0)
            {
                foreach (var t in testators)
                {
                    await testatorService.CreateTestator(t);
                }                
            }
        }

        public Testator GetTestatorById(int id) => testators.FirstOrDefault(t => t.Id == id);

        public void DeleteTestator(int id)
        {
            var testator = GetTestatorById(id);
            if (testator != null)
            {
                testators.Remove(testator);
            }
        }

        public void EstablishRelationToHeir(Heir heir, int? selectedTestatorId)
        {

            if (selectedTestatorId.HasValue)
            {
                var newTestator = testators.FirstOrDefault(t => t.Id == selectedTestatorId);

                if (newTestator != null && !newTestator.Heirs.Any(h => h.Id == heir.Id))
                {
                    newTestator.Heirs.Add(heir);
                }
            }
        }

    }
}
