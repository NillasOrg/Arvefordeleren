namespace Arvefordeleren.Models.Repositories
{
    public class TestatorRepository
    {
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
            testator.Id = maxId + 1;
            testators.Add(testator);
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

        
    }
}
