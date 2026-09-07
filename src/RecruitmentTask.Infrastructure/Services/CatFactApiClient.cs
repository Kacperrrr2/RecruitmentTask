using RecruitmentTask.Domain.DomainEntities;
using RecruitmentTask.Domain.Interfaces.Services;
using System.Net.Http.Json;

namespace RecruitmentTask.Infrastructure.Services;

public class CatFactApiClient : ICatFactApiClient
{
    private readonly HttpClient _httpClient;
    public CatFactApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<CatFact?> GetCatFactAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact", cancellationToken);
    }
}