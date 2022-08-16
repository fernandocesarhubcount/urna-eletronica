using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TesteHubCount.Models
{
  public class CandidateModel
  {
    public CandidateModel(string nome, string vice, int legenda, DateTime dataRegistro)
    {
      this.Nome = nome;
      this.Vice = vice;
      this.Legenda = legenda;
      this.DataRegistro = dataRegistro;
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nome { get; set; }

    [Required, MinLength(2), MaxLength(100)]
    public string Vice { get; set; }

    [Required, Range(1, 99)]
    public int Legenda { get; set; }

    [Required]
    public DateTime DataRegistro { get; set; }
  }
}