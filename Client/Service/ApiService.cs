using Shared;
using System.Net.Http.Json;

public class ApiService
{
    private readonly HttpClient httpClient;

    public ApiService(HttpClient httpClient)
    {
        // Set the base address for the HttpClient here
        httpClient.BaseAddress = new Uri("https://localhost:7018"); // Use the correct server URL with https
        this.httpClient = httpClient;
    }

    public async Task<Tråde[]> GetTrådesAsync()
    {
        return await httpClient.GetFromJsonAsync<Tråde[]>("/api/tråde"); // Use the correct API endpoint
    }
}
