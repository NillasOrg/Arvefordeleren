using Arvefordeleren.Models;

namespace Arvefordeleren.Services
{
    public class AppState
    {
        public List<Testator> Testators { get; set; } = new();
        public List<Asset> Assets { get; set; } = new();
        public List<Heir> Heirs { get; set; } = new();

        public void ClearAllData()
        {
            Testators.Clear();
            Assets.Clear();
            Heirs.Clear();
        }
    }
}
