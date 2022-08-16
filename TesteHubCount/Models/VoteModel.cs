using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteHubCount.Models
{

  public class VoteModel
  {
    public VoteModel(DateTime dataDoVoto, int candidatoId)
    {
      this.DataDoVoto = dataDoVoto;
      this.CandidatoId = candidatoId;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public DateTime DataDoVoto { get; set; }

    [Required]
    [ForeignKey("CandidateModelId")]
    public int CandidatoId { get; set; }

  }

}