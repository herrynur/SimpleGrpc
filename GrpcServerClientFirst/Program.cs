using GrpcServerClientFirst.Grpc;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.ConfigureKestrel(option =>
{
    option.ListenAnyIP(6200, listenOptions => listenOptions.Protocols = HttpProtocols.Http1);
    option.ListenAnyIP(6020, listenOptions => listenOptions.Protocols = HttpProtocols.Http2);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GrpcServices>();
    endpoints.MapControllers();
});

app.Run();
