using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieCharactersApi.Data;
using MovieCharactersApi.Services;
using System.Reflection;
using System.Text.Json.Serialization;

namespace MovieCharactersApi;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddJsonOptions(o =>
        {
            o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            o.JsonSerializerOptions.MaxDepth = 0;
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "MovieCharactersAPI",
                Description = "API for movie characters",
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        var configuration = builder.Configuration;
        builder.Services.AddDbContextPool<DatabaseContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString("MovieCharactersDatabase")));

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddScoped<ICharactersService, CharactersService>();
        builder.Services.AddScoped<IMoviesService, MoviesService>();
        builder.Services.AddScoped<IFranchiseService, FranchiseService>();

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
    }
}
