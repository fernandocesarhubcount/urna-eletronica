using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Controllers.Commands;

namespace UrnaEletronica.Model.Inputs
{
    public class FormVoto : Notifiable, IComando
    {
        public int? IdCandidato { get; set; }
        public DateTime DataDoVoto { get; set; }
        public bool VotoEmBranco { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .IsNotNull(DataDoVoto, nameof(DataDoVoto), "A data não pode ser nula")
                .IsNotNull(VotoEmBranco, nameof(VotoEmBranco), "Por favor, definir se o voto é em branco ou não.")
                .IsFalse((IdCandidato != null && VotoEmBranco), nameof(VotoEmBranco), "Não é possível gravar um voto em branco que tenha a legenda do candidato ")
            );

            return IsValid;
        }
    }
}
