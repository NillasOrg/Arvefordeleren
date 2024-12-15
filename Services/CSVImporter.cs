using System.Globalization;
using System.Text;
using Arvefordeleren.Models;
using Arvefordeleren.Models.Repositories;
using CsvHelper;

namespace Arvefordeleren.Services;

public class CSVImporter
{
    
    private readonly TestatorRepository TestatorRepository;
    private readonly HeirsRepository HeirsRepository;

    public CSVImporter(TestatorRepository testatorRepository, HeirsRepository heirsRepository)
    {
        TestatorRepository = testatorRepository;
        HeirsRepository = heirsRepository;
    }
    
    public async Task ReadHeirs(Stream stream)
    {
        HeirsRepository.Heirs.Clear();
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecordsAsync<Heir>();
            await foreach (var heir in records)
            {
                HeirsRepository.AddHeir(heir);
            }
        }
    }
    
    public async Task ReadAssets(Stream stream)
    {
        AssetsRepository.Assets.Clear();
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecordsAsync<Asset>();
            await foreach (var asset in records)
            {
                AssetsRepository.AddAsset(asset);
            }
        }
    }
    
    public async Task ReadTestators(Stream stream)
    {
        TestatorRepository.Testators.Clear();
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecordsAsync<Testator>();
            await foreach (var testator in records)
            {
                TestatorRepository.AddNewTestator(testator);
            }
        }
    }
}
