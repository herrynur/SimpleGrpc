using GrpcServerClientSecond;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.ConfigureKestrel(option =>
{
    option.ListenAnyIP(5200, listenOptions => listenOptions.Protocols = HttpProtocols.Http1);
    option.ListenAnyIP(5020, listenOptions => listenOptions.Protocols = HttpProtocols.Http2);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpcConfiguration(builder.Configuration);
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
