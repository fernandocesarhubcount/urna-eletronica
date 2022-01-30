using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Controllers.Commands;

namespace UrnaEletronica.Model.Inputs
{
    public class FormularioCandidato: Notifiable, IComando
    {
        public string NomeCompleto { get; set; }
        public string NomeVice { get; set; }
        public DateTime DataDeRegistro { get; set; }
        public Int32 Legenda { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .IsNotNull(NomeVice, nameof(NomeVice), "O nome do vice não pode ser nullo")
                .IsNotNullOrEmpty(NomeCompleto, nameof(NomeCompleto), "O nome completo do candidato não deve ser vazio ou nulo")
                .IsNotNullOrEmpty(NomeVice, nameof(NomeVice), "O nome do vice não deve ser vazio ou nulo")
                .IsGreaterThan(Legenda, 0, "Legenda", "A legenda do candidato deve ser um número positivo")
            );

            return IsValid;
        }
    }
}
