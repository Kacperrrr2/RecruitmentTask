using RecruitmentTask.Domain.DomainEntities;
using RecruitmentTask.Domain.Interfaces.Repositories;
using RecruitmentTask.Domain.Interfaces.Services;

namespace RecruitmentTask.Application.UseCases;

public class FetchAndSaveCatFactUseCase
{
    private readonly ICatFactApiClient _apiClient;
    private readonly IFactRepository  _factRepository;
    
    public FetchAndSaveCatFactUseCase(ICatFactApiClient apiClient, IFactRepository factRepository)
    {
        _apiClient = apiClient;
        _factRepository = factRepository;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var fact = await _apiClient.GetCatFactAsync(cancellationToken);
        if(fact is null)
        {
            throw new InvalidOperationException("Failed to retrieve cat fact from external API.");
        }
        await _factRepository.AppendAsync(fact);
    }
}