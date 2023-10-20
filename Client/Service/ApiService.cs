using Shared;
using System.Net.Http;
using System.Net.Http.Json;

public class ApiService
{
    private readonly HttpClient httpClient;


    public ApiService(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri("https://localhost:7018");
        this.httpClient = httpClient;
    }

    public async Task<Tråde[]> GetTrådesAsync()
    {
        return await httpClient.GetFromJsonAsync<Tråde[]>("/api/tråde");
    }

    // PostTrådeAsync metoden accepterer et Tråde objekt som parameter hvilket er de data du ønsker at sende til serveren.
    public async Task<Tråde> PostTrådeAsync(Tråde tråd)
    {
        // Den bruger PostAsJsonAsync-metoden til at sende en POST anmodning til serveren med Tråde objektet som JSON data i anmodningens krop
        var response = await httpClient.PostAsJsonAsync("/api/tråde", tråd);
        // Den tjekker om anmodningen var vellykket ved at sikre at statuskoden er 200(success)
        response.EnsureSuccessStatusCode();
        // Derefter tager den JSON format respons fra serveren (deserialisere) og omdanner den til et objekt som kan arbejdes med i koden.
        return await response.Content.ReadFromJsonAsync<Tråde>();
    }
}
