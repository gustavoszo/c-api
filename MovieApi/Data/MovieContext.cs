using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieApi.Models;

namespace MovieApi.Data
{
    // A classe MovieContext herda de DbContext, que é a classe base do EF Core para interagir com o banco de dados. O DbContext gerencia a comunicação entre o banco de dados e as suas entidades
    public class MovieContext: DbContext
    {

        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
        { }

        //  Isso representa a tabela Movies no banco de dados. O DbSet é uma coleção de todas as entidades do tipo Movie. O EF Core cria automaticamente uma tabela chamada Movies (a menos que você defina um nome diferente usando [Table("NomeTabela")]) baseada nesta propriedade.
        public DbSet<Movie> Movies { get; set; }

    }
}
