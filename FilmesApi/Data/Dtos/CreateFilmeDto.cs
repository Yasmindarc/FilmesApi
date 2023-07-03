using System.ComponentModel.DataAnnotations;
namespace FilmesApi.Data.Dtos; 
public class CreateFilmeDto {

   
    [Required(ErrorMessage = "O Título do filme é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O Gênero do filme é obrigatório")]
    [StringLength(60, ErrorMessage = "O Tamanho não pode exceder 60 caracteres")]
    public string Genero { get; set; }
    [Required]
    [Range(70, 500, ErrorMessage = "A Duracao deve ter entre 70 e 500 Minutos")]
    public int Duracao { get; set; }
}
