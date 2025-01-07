using System.Globalization;
using System.Text;
using Arvefordeleren.Models;
using Arvefordeleren.Models.Repositories;
using CsvHelper;

namespace Arvefordeleren.Services;

public class CSVImporter
{
    private readonly HeirsRepository _heirsRepository;
    private readonly AssetsRepository _assetsRepository;
    private readonly TestatorRepository _testatorRepository;

    // Constructor injection for dependencies
    public CSVImporter(HeirsRepository heirsRepository, AssetsRepository assetsRepository, TestatorRepository testatorRepository)
    {
        _heirsRepository = heirsRepository;
        _assetsRepository = assetsRepository;
        _testatorRepository = testatorRepository;
    }

    public async Task ReadHeirs(Stream stream)
    {
        _heirsRepository.Heirs.Clear();
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecordsAsync<Heir>();
            await foreach (var heir in records)
            {
                _heirsRepository.AddHeir(heir);
            }
        }
    }

    public async Task ReadAssets(Stream stream)
    {
        _assetsRepository.Assets.Clear();
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecordsAsync<Asset>();
            await foreach (var asset in records)
            {
                _assetsRepository.AddAsset(asset);
            }
        }
    }

    public async Task ReadTestators(Stream stream)
    {
        _testatorRepository.testators.Clear();
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecordsAsync<Testator>();
            await foreach (var testator in records)
            {
                _testatorRepository.AddNewTestator(testator);
            }
        }
    }
}
