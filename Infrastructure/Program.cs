using Application;
using Application.Common.Interfaces;
using Infrastructure.Api.Common;
using Infrastructure.DAL.EntityFramework;
using Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new CustomDateTimeConverter());
    });

    builder.Services.AddDbContext<TelegramBotDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
    });

    builder.Services.AddScoped<IPersonRepository, PersonRepository>();

    builder.Services.AddApplication();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}