using RecruitmentTask.Domain.DomainEntities;

namespace RecruitmentTask.Domain.Interfaces.Repositories;

public interface IFactRepository
{
    Task AppendAsync(CatFact fact, CancellationToken cancellationToken = default);
}