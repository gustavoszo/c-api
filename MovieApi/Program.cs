
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
            Adiciona ao container de injeção de dependência do .NET um serviço do tipo DbContext com a classe FilmeContext.
            Isso permite que o FilmeContext seja injetado automaticamente em outros serviços ou controladores que precisem dele.

            (opts => opts.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString))): 
            Configura o DbContext para usar o MySQL como o provedor de banco de dados. O método UseMySql recebe dois parâmetros: a string de conexão com o banco de dados e a versão do servidor MySQL.
            A string de conexão contém as informações necessárias para conectar ao banco de dados, como o servidor, o nome do banco de dados, o usuário e a senha. O método ServerVersion.AutoDetect(connectionString) é usado para detectar automaticamente a versão do servidor MySQL.
            */
            builder.Services.AddDbContext<MovieContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddControllers();
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
