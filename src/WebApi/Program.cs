using Application;
using Infrastructure;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApi();
builder.Services.AddApplicationLayer();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
