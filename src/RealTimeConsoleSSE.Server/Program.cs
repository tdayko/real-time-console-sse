using RealTimeConsoleSSE.Server;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:8080");
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.MapSSEEndpoint();
app.UseDeveloperExceptionPage();
app.UseRouting();

app.Run();