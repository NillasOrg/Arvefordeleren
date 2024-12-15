namespace Arvefordeleren.Models.Repositories
{
    public class TestatorRepository
    {
        private readonly StorageService _storageService;
        public List<Testator> Testators { get; private set; } = new List<Testator>();

        public TestatorRepository(StorageService storageService)
        {
            _storageService = storageService;
        }
        
        public void AddNewTestator(Testator testator)
        {
            int maxId = Testators.Any() ? Testators.Max(t => t.Id) : 0;
            testator.Id = maxId + 1;
            Testators.Add(testator);
        }

        public Testator? GetTestatorById(int id) => Testators.FirstOrDefault(t => t.Id == id);

        public void DeleteTestator(int id)
        {
            var testator = GetTestatorById(id);
            if (testator != null)
            {
                Testators.Remove(testator);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _storageService.SaveAsync("testators", Testators);
        }
    }
}