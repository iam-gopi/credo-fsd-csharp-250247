using System.Text;
using System.Text.Json;

namespace Credo_fsd;

class Student
{
    public string Name { get; set; }
    public string Dept { get; set; }
}

public class HttpSend
{
    public static void Main(String[] args)
    {
        HttpClient client = new HttpClient();
        // HttpRequestMessage request = new HttpRequestMessage()
        // {
        //     Method = HttpMethod.Get,
        //     RequestUri = new Uri("https://69b16764adac80b427c50bf5.mockapi.io/api"),
        // };
        // var response = client.Send(request);
        //
        // Console.WriteLine(response.Content.ReadAsStringAsync().Result);

        var data = new Student()
        {
            Name = "kannan",
            Dept = "IT"
        };
        var bodyContent = JsonSerializer.Serialize(data);
        try
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://69b16764adac80b427c50bf5.mockapi.io/api"),
                Content = new StringContent(bodyContent, Encoding.UTF8)
            };
            var response = client.Send(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}