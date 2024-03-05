using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using ConsoleApp1;

class Program
{
    static async Task Main()
    {
        ApiClient apiClient = new ApiClient();

        string apiUrlGet = "https://languagetool.org/api/v2/languages";
        var responseGet = await apiClient.Get<string>(apiUrlGet);
        Console.WriteLine($"GET request result:\nStatus: {responseGet.Message}\nHTTP Status Code: {responseGet.HttpStatusCode}");
        if (responseGet.Data != null)
        {
            foreach (var item in responseGet.Data)
            {
                Console.WriteLine($"Code: {item.code}, Long Code: {item.longCode}, Name: {item.name}");
            }
        }

        string apiUrlPost = "https://languagetool.org/api/v2/check";
        object requestData = new
        {
            Parameter1 = "Value1",
            Parameter2 = "Value2"
        };

        var responsePost = await apiClient.Post<string>(apiUrlPost, requestData);
        Console.WriteLine($"POST request result:\nStatus: {responsePost.Message}\nHTTP Status Code: {responsePost.HttpStatusCode}");
        if (responsePost.Data != null)
        {
            Console.WriteLine($"Data: {responsePost.Data}");
        }
    }

}
