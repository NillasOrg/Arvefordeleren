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

        //public async Task<Asset> UpdateAsset(Asset assetToBeUpdated)
        //{
        //    var content = new StringContent(JsonSerializer.Serialize(assetToBeUpdated), Encoding.UTF8, "application/json");
        //    using (HttpResponseMessage response = await APIContext._apiClient.PutAsync("/api/assets", content))
        //    {
        //        if(response.IsSuccessStatusCode)
        //        {
        //            Asset updatedAsset = await response.Content.ReadFromJsonAsync<Asset>();
        //            return updatedAsset;
        //        }

        //        throw new Exception(response.ReasonPhrase);
        //    }
        //}

        //public async Task<Asset?> GetAssetById(int id)
        //{
        //    return await _httpClient.GetFromJsonAsync<Asset>($"api/assets/{id}");
        //}
    }
}
