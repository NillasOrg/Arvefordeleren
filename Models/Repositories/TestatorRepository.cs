namespace Arvefordeleren.Models.Repositories
{
    public static class TestatorRepository
    {
        public static List<Testator> testators { get; set; } = new List<Testator>();

        public static void AddNewTestator(Testator testator)
        {
            int maxId = testators.Any() ? testators.Max(t => t.Id) : 0; // Hvis listen er tom, start med ID 1
            testator.Id = maxId + 1;
            testators.Add(testator);
        }

        public static Testator GetTestatorById(int id) => testators.FirstOrDefault(t => t.Id == id);

        public static void DeleteTestator(int id)
        {
            var testator = GetTestatorById(id);
            if (testator != null)
            {
                testators.Remove(testator);
            }
        }

        
    }
}
