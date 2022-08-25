using teamServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();

//Dependency injection: https://en.wikipedia.org/wiki/Dependency_injection, https://exceptionnotfound.net/dependency-injection-in-dotnet-6-service-lifetimes/
//https://stackoverflow.com/questions/55845137/what-are-services-and-why-add-them-in-asp-net-core
builder.Services.AddSingleton<IListenerServices, ListenerServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
