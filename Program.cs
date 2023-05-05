using Microsoft.EntityFrameworkCore;
using Model;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection"));
});

var MyAllowedSpecificOrigins = "_myallowedspecificorigins";

builder.Services.AddCors(options => {
    options.AddPolicy(name:MyAllowedSpecificOrigins, policy => {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowedSpecificOrigins);

app.MapControllers();

app.Run();
