using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Server.Extensions;
using HawksNestGolf.NET.Server.Middleware;
using HawksNestGolf.NET.Server.Repositories;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

namespace HawksNestGolf.NET
{
    public class Program
    {
        private static string XmlCommentsPath => 
            Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //
            // Add services to the container.
            //

            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(XmlCommentsPath);
            });

            // Add Database
            builder.Services.AddDbContext<HawksNestGolfDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("HawksNestGolfDb");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            // Add Repositories
            builder.Services.AddRepositories();

            // Add Controllers and JsonOptions to avoid circular references
            builder.Services.AddControllersWithViews().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddRazorPages();

            var app = builder.Build();

            //
            // Configure the HTTP request pipeline.
            //
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();

                // Add Swagger
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}