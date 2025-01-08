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
            using (HttpResponseMessage response = await APIContext._apiClient.PostAsJsonAsync("/api/testators", testator))
            {
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Arvelader blev tilføjet!");
                    return testator;
                }

                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

    }
}
