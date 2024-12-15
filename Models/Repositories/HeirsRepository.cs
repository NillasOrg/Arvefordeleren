namespace Arvefordeleren.Models.Repositories
{
    public class HeirsRepository
    {
        private readonly StorageService _storageService;

        public List<Heir> Heirs { get; private set; } = new List<Heir>();

        public HeirsRepository(StorageService storageService)
        {
            _storageService = storageService;
            LoadHeirs();
        }
        
        public async void AddHeir(Heir heir)
        {
            heir.Id = Heirs.Count + 1;
            Heirs.Add(heir);
            await SaveChangesAsync();
        }

        public async void RemoveHeir(int id)
        {
            Heir heir = Heirs.FirstOrDefault(b => b.Id == id);

            if (heir != null)
            {
                Heirs.Remove(heir);
                await SaveChangesAsync();
            }
        }
        
        public async Task SaveChangesAsync()
        {
            await _storageService.SaveAsync("heirs", Heirs);
        }

        private async void LoadHeirs()
        {
            Heirs = await _storageService.LoadAsync<Heir>("heirs");
        }
     }
}
