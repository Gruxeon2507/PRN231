using Microsoft.EntityFrameworkCore;
using VerbHppt.Controllers;
using VerbHppt.Models;

namespace VerbHppt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("CORSPolicy", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed((host) => true));
            });
            builder.Services.AddDbContext<PRN_Sum22_B1Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<PRN_Sum22_B1Context>(); // thêm dependence
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("CORSPolicy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}