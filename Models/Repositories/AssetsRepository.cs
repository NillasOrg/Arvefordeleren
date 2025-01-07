using Arvefordeleren.Data;

namespace Arvefordeleren.Models.Repositories;

public class AssetsRepository
{
    // Instance-level properties
    public List<Asset> Assets { get; set; } = new List<Asset>();
    public bool Car { get; set; } = false;
    public bool Home { get; set; } = false;
    public string? Note { get; set; }
    public bool TempBool { get; set; } = false;

    
    private readonly DataContext _dataContext;

    public AssetsRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void AddAsset(Asset asset)
    {
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