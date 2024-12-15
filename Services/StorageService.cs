using Arvefordeleren.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

public class StorageService
{
    private readonly ProtectedSessionStorage _sessionStorage;

    public StorageService(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public async Task SaveAsync<T>(String key, List<T> testator)
    {
        await _sessionStorage.SetAsync(key, testator);
    }

    public async Task<List<T>> LoadAsync<T>(string key)
    {
        var result = await _sessionStorage.GetAsync<List<T>>(key);
        if (result.Value != null)
        {
            return result.Value;
        }
        return null;
    }
}