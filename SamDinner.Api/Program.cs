
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SamDinner.Api.Common.Errors;
using SamDinner.Application;
using SamDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, SamDinnerProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


