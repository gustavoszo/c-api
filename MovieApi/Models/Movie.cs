using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Movie
    {
        public static int cont = 1;

        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "O nome do filme deve ter no minimo 2 caracteres")]
        public String Title { get; set; }

        [Required]
        public String Type { get; set; }

        [Required]
        [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
        public int Duration { get; set; } 

        public Movie() 
        {
            Id = cont; 
            cont++;
        }
    }
}
