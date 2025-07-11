using Damilah_School_Subject_App.Domain;
using Damilah_School_Subject_App.Service.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Damilah_School_Subject_App.Service.Implementation
{
    public class ExternalApiHandlerService : IExternalApiHandlerService
    {
        private readonly HttpClient httpClient = new HttpClient();

        public async Task<List<Subject>> FetchExternalSubjectsFromApi()
        {
            string url = "https://markosimka.github.io/subjects.json";
            List<Subject> subjects = new List<Subject>();
            try
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                JArray data = JArray.Parse(responseBody);

                return JsonConvert.DeserializeObject<List<Subject>>(data.ToString()) ?? [];

            }
            catch (HttpRequestException ex)
            {
                Console.Write("Request error: ", ex.ToString());
            }

            return new List<Subject>();
        }
    }
}
