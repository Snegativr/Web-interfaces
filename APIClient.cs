using ConsoleApp1;
using Newtonsoft.Json;
using System.Net.Http.Headers;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<ResponseModel<LanguageData>> Get<T>(string apiUrl)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            List<LanguageData> data = JsonConvert.DeserializeObject<List<LanguageData>>(responseData);

            return new ResponseModel<LanguageData>
            {
                Message = "Success",
                HttpStatusCode = (int)response.StatusCode,
                Data = data
            };
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new ResponseModel<LanguageData>
            {
                Message = "Error",
                HttpStatusCode = 500,
                Data = null
            };
        }
    }

    public async Task<ResponseModel<string>> Post<T>(string apiUrl, object requestData)
    {
        try
        {
            string json = JsonConvert.SerializeObject(requestData);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();
            List<string> data = JsonConvert.DeserializeObject<List<string>>(responseData);

            return new ResponseModel<string>
            {
                Message = "Success",
                HttpStatusCode = (int)response.StatusCode,
                Data = data
            };
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new ResponseModel<string>
            {
                Message = "Error",
                HttpStatusCode = 500,
                Data = null
            };
        }
    }

}