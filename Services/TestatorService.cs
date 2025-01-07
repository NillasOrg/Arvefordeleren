using Arvefordeleren.Data;
using Arvefordeleren.Models;
using Arvefordeleren.Models.Repositories;
using System.Text;
using System.Text.Json;

namespace Arvefordeleren.Services
{
    public class TestatorService
    {

        

        public TestatorService()
        {
            APIContext.Initialize();
            
        }

        public async Task<Testator> CreateTestator(Testator testator)
        {
            var content = new StringContent(JsonSerializer.Serialize(testator), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await APIContext._apiClient.PostAsJsonAsync("/api/testators", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    //Testator testatorToBeCreated = await response.Content.ReadFromJsonAsync<Testator>();
                    //return testatorToBeCreated;
                }

                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

       
    }
}
