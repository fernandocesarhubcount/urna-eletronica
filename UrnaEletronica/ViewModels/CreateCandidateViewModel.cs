using System.ComponentModel.DataAnnotations;

namespace UrnaEletronica.ViewModels
{
    public class CreateCandidateViewModel
    {
        [Required(ErrorMessage = "O nome deve ser informado")]
        [MinLength(3, ErrorMessage = "Nome inválido, informe no mínimo 3 caracteres")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$",ErrorMessage = "caracteres inválidos")]
        public string NomeCanditato { get; set; }
        
        [Required(ErrorMessage = "O nome deve ser informado")]
        [MinLength(3, ErrorMessage = "Nome inválido, informe no mínimo 3 caracteres")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$", ErrorMessage = "caracteres inválidos")]
        public string NomeVice { get; set; }
        
        [Required(ErrorMessage = "A legenda deve ser informada")]
        [Range(0, 99)]
        public int Legenda { get; set; }
    }
}
