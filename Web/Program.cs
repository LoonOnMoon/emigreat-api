var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

EmiGreat.Business.Infrastructure.Extensions.Startup.ConfigureServices(builder.Services, builder.Environment.EnvironmentName, new EmiGreat.Web.Infrastructure.Mapper.WebMapperProfile());
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
