using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }

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
