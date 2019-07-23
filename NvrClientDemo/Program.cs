using Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NvrClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task<NvrSchedule> MainAsync()
        {
            var client = new HttpClient();
            var nvrSchedule = default(NvrSchedule);
            HttpResponseMessage response = await client.GetAsync(@"https://localhost:44396/api/values");
            if (response.IsSuccessStatusCode)
            {
                var strResponse = await response.Content.ReadAsStringAsync();
                nvrSchedule = JsonConvert.DeserializeObject<NvrSchedule>(strResponse);
            }
            return nvrSchedule;
        }
    }
}
