
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MySqlConnector;

namespace MovieApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("movieConnection");

            /*
            builder.Services.AddDbContext<FilmeContext>:
            Adiciona ao container de inje��o de depend�ncia do .NET um servi�o do tipo DbContext com a classe FilmeContext.
            Isso permite que o FilmeContext seja injetado automaticamente em outros servi�os ou controladores que precisem dele.

            (opts => opts.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString))): 
            Configura o DbContext para usar o MySQL como o provedor de banco de dados. O m�todo UseMySql recebe dois par�metros: a string de conex�o com o banco de dados e a vers�o do servidor MySQL.
            A string de conex�o cont�m as informa��es necess�rias para conectar ao banco de dados, como o servidor, o nome do banco de dados, o usu�rio e a senha. O m�todo ServerVersion.AutoDetect(connectionString) � usado para detectar automaticamente a vers�o do servidor MySQL.
            */
            builder.Services.AddDbContext<MovieContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers().AddNewtonsoftJson();
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
