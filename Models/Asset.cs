using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Arvefordeleren.Models;

public class Asset
{
    public int Id { get; set; }
    public AssetType Type { get; set; }

    
    public string? Note { get; set; } 
    public bool IsCar { get; set; }
    public bool IsHome { get; set; }
    public bool IsTempBool { get; set; }

    public string Icon 
    {
        get
        {
            switch (Type)
            {
                case AssetType.Køretøj:
                    return "/images/Car.png";

                case AssetType.Bolig:
                    return "/images/home.png";

                case AssetType.Værdigenstand:
                    return "/images/valuables.png";

                default:
                    return "/images/favicon.png";
            }
        }    
    }

    public Asset() {}

    public Asset(AssetType type)
    {
        Type = type;
    }

    public Asset(int id, AssetType type, string? note, bool isCar, bool isHome)
    {
        Id = id;
        Type = type;
        Note = note;
        IsCar = isCar;
        IsHome = isHome;
    }
}

public enum AssetType
{
    Køretøj, Bolig, Værdigenstand
}