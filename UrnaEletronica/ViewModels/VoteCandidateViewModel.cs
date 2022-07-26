using System.ComponentModel.DataAnnotations;

namespace UrnaEletronica.ViewModels
{
    public class VoteCandidateViewModel
    {
        [Required(ErrorMessage = "A legenda deve ser informada")]
        [Range(0, 99)]
        public int Legenda { get; set; }
    }
}
