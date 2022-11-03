using System.Net.Http.Json;

namespace NetHttpClientJsonProject
{
    class User
    {
        public string? Name { set; get; }
        public int Age { set; get; }
    }
    internal class Program
    {
        static string serverUrl = @"http://efimovlg.beget.tech";

        static HttpClient client = new();
        static async Task Main(string[] args)
        {
            //object? dataJson = await client.GetFromJsonAsync(serverUrl + "/json/ex.json", typeof(User));
            //if(dataJson is User user)
            //{
            //    Console.WriteLine($"{user.Name} {user.Age}");
            //}

            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla Firefox");
            client.DefaultRequestHeaders.Add("MyCode", "Maxim");

            using var response = await client.GetAsync(serverUrl);
            foreach (var header in response.Headers)
            {
                Console.Write($"{header.Key}: ");
                foreach (var value in header.Value)
                    Console.WriteLine(value);
            }
        }
    }
}