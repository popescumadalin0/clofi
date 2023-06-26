using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SDK;

public class RefitApiClient<T>
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public RefitApiClient(string baseUrl)
    {
        _baseUrl = baseUrl;
        _httpClient = new HttpClient();
    }

    public async Task<TResponse> Execute<TRequest, TResponse>(string endpoint, TRequest request)
    {
        var fullUrl = $"{_baseUrl}/{endpoint}";

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, fullUrl);
        httpRequest.Content = new StringContent(request.ToString()); // adjust this based on the actual request format

        var response = await _httpClient.SendAsync(httpRequest);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();

        // Adjust this part based on the actual response format
        var responseObject = JsonConvert.DeserializeObject<TResponse>(responseBody);

        return responseObject;
    }
}