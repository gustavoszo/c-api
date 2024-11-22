using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class CreateMovieDto
    {

        [Required]
        [MinLength(2, ErrorMessage = "O nome do filme deve ter no minimo 2 caracteres")]
        [Column(TypeName = "VARCHAR(255)")]
        public String Title { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public String Type { get; set; }

        [Required]
        [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
        public int Duration { get; set; }

    }
}
