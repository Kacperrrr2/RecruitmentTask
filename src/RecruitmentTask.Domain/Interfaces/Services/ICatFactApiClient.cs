using RecruitmentTask.Domain.DomainEntities;

namespace RecruitmentTask.Domain.Interfaces.Services;

public interface ICatFactApiClient
{
    Task<CatFact?> GetCatFactAsync(CancellationToken cancellationToken = default);
}