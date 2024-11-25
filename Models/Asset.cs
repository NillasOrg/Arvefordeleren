﻿namespace Arvefordeleren.Models;

public class Asset
{
    public int Id { get; set; }
    public AssetType Type { get; set; }
    public string? Note { get; set; }

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
}

public enum AssetType
{
    Køretøj, Bolig, Værdigenstand
}