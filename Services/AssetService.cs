using Arvefordeleren.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Arvefordeleren.Data
{
    public class AssetService
    {
        private readonly HttpClient _httpClient;

        public AssetService()
        {
            APIContext.Initialize();
        }

        public async Task<Asset> CreateAsset(Asset asset)
        {
            
            using (HttpResponseMessage response = await APIContext._apiClient.PostAsJsonAsync("/api/assets", asset))
            {
                if (response.IsSuccessStatusCode)
                {
                   return asset;
                }

                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
           
    }
}
