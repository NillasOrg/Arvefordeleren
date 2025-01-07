using System.Net;


namespace Arvefordeleren.Data
{
    public class APIContext
    {
       public static HttpClient _apiClient;

        public static void Initialize()
        {
            var handler = new HttpClientHandler();
            _apiClient = new HttpClient(handler);

            _apiClient.BaseAddress = new Uri("https://localhost:7231");
        }
    }
}


