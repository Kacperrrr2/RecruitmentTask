using RecruitmentTask.Application.UseCases;
using RecruitmentTask.Domain.Interfaces.Repositories;
using RecruitmentTask.Domain.Interfaces.Services;
using RecruitmentTask.Infrastructure.Repositories;
using RecruitmentTask.Infrastructure.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

string mainFolderPath = Path.Combine(builder.Environment.ContentRootPath, "cat_facts.txt");
builder.Services.AddTransient<IFactRepository>(sp => new TxtFactRepository(mainFolderPath));
builder.Services.AddHttpClient<ICatFactApiClient, CatFactApiClient>();
builder.Services.AddTransient<FetchAndSaveCatFactUseCase>();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new()
        {
            Title = "Cat Fact Management API",
            Version = "v1",
            Description = "API to download radom fact about cat  ( site: catfact.ninja) and save in file.txt."
        };
        return Task.CompletedTask;
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapPost("/api/cat-facts/fetch", async (
        FetchAndSaveCatFactUseCase useCase, 
        CancellationToken ct) =>
    {
        try
        {
            await useCase.ExecuteAsync(ct);
            return Results.Ok(new CatFactResponse("Cat fact fetched and saved successfully."));
        }
        catch (InvalidOperationException ex)
        {
            return Results.Problem(
                detail: ex.Message,
                statusCode: StatusCodes.Status502BadGateway,
                title: "External API Integration Error"
            );
        }
    })
    .WithName("FetchCatFact")
    .WithTags("Cat Facts")
    .WithSummary("Fetch and save a random cat fact")
    .WithDescription("Triggers fetching a fresh cat fact from the external API and appends it to the local file cat_facts.txt.")
    .Produces<CatFactResponse>(StatusCodes.Status200OK)
    .ProducesProblem(StatusCodes.Status502BadGateway);

app.Run();

public record CatFactResponse(string Message);