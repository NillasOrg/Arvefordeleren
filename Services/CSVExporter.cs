using System.Globalization;
using System.IO.Compression;
using System.Text;
using Arvefordeleren.Models;
using CsvHelper;

namespace Arvefordeleren.Services;

public static class CSVExporter
{
    public static void AssetsExport(List<Asset> assets)
    {
        using (var writer = new StreamWriter("Data/Downloads/Assets.csv", false, Encoding.UTF8))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(assets);
        }
    }
    
    public static void HeirsExport(List<Heir> heirs)
    {
        using (var writer = new StreamWriter("Data/Downloads/Heirs.csv", false, Encoding.UTF8))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(heirs);
        }
    }
    
    public static void TestatorsExport(List<Testator> testators)
    {
        using (var writer = new StreamWriter("Data/Downloads/Testators.csv", false, Encoding.UTF8))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(testators);
        }
    }
}