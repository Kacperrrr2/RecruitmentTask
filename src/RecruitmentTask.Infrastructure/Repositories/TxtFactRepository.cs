namespace RecruitmentTask.Infrastructure.Repositories;

using RecruitmentTask.Domain.DomainEntities;
using RecruitmentTask.Domain.Interfaces.Repositories;

public class TxtFactRepository : IFactRepository
{
    private readonly string _filePath;
    public TxtFactRepository(string filePath)
    {
        _filePath = filePath;
    }
    

    public async Task AppendAsync(CatFact fact, CancellationToken cancellationToken = default)
    {
        var line = $"{fact.Fact} (Length: {fact.Length}){Environment.NewLine}";
        await File.AppendAllTextAsync(_filePath, line, cancellationToken);
    }
}