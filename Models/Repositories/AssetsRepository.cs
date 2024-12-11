namespace Arvefordeleren.Models.Repositories;

public static class AssetsRepository
{

    public static List<Asset> Assets { get; set; } = new List<Asset>();
    public static bool Car { get; set; } = false;
    public static bool Home { get; set; } = false;
    public static bool TempBool { get; set; } = false;


    public static void AddAsset(Asset asset)
    {
        asset.Id = Assets.Count + 1;
        Assets.Add(asset);
    }

    public static void RemoveAsset(int id)
    {
        Asset asset = Assets.FirstOrDefault(a => a.Id == id);

        if (asset != null)
        {
            Assets.Remove(asset);
        }
    }

    public static Asset? GetAssetById(int id)
    {
        Asset? asset = Assets.FirstOrDefault(a => a.Id == id);
        
        if (asset == null)
        {
            throw new InvalidOperationException($"Aktiv med Id {id} blev ikke fundet.");
        }

        return asset;
    }

    public static void UpdateAsset(Asset asset)
{
    var existingAsset = Assets.FirstOrDefault(a => a.Id == asset.Id);
    if (existingAsset != null)
    {
        existingAsset.IsCar = asset.IsCar;
    }
}

}
