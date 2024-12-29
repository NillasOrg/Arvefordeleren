namespace Arvefordeleren.Models.Repositories;

public class AssetsRepository
{
    // Instance-level properties
    public List<Asset> Assets { get; set; } = new List<Asset>();
    public bool Car { get; set; } = false;
    public bool Home { get; set; } = false;
    public bool TempBool { get; set; } = false;

    // Methods
    public void AddAsset(Asset asset)
    {
        asset.Id = Assets.Count + 1;
        Assets.Add(asset);
    }

    public void RemoveAsset(int id)
    {
        Asset asset = Assets.FirstOrDefault(a => a.Id == id);

        if (asset != null)
        {
            Assets.Remove(asset);
        }
    }

    public Asset? GetAssetById(int id)
    {
        Asset? asset = Assets.FirstOrDefault(a => a.Id == id);
        
        if (asset == null)
        {
            throw new InvalidOperationException($"Aktiv med Id {id} blev ikke fundet.");
        }

        return asset;
    }

    public void UpdateAsset(Asset asset)
    {
        var existingAsset = Assets.FirstOrDefault(a => a.Id == asset.Id);
        if (existingAsset != null)
        {
            existingAsset.IsCar = asset.IsCar;
        }
    }
}