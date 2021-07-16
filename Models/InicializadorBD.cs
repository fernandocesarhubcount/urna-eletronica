using System;
using System.Linq;
using UrnaEletronica.Util;

namespace UrnaEletronica.Models
{
    public static class InicializadorBD
    {
        public static void Inicializador(MyDbContext contexto)
        {
            contexto.Database.EnsureCreated();

            if (contexto.Candidatos.Any())
            {
                return;
            }

            // Adicionando candidatos ficticios
            DateTime dataRegistro = new DateTime(2021, 2, 13);
            Candidato[] candidatos = new Candidato[]
            {
                new Candidato {Codigo = Constantes.CodigosVotos.Nulo.GetHashCode(), Nome = Constantes.Nulo, Partido= "-", Vice = "-", DataRegistro = dataRegistro},
                new Candidato {Codigo = Constantes.CodigosVotos.Branco.GetHashCode(), Nome = Constantes.Branco, Partido= "-", Vice = "-", DataRegistro = dataRegistro},
                new Candidato {Codigo = 10, Nome = "Prefeito 10", Partido= "A", Vice = "Vice 10", DataRegistro = dataRegistro},
                new Candidato {Codigo = 11, Nome = "Prefeito 11", Partido= "B", Vice = "Vice 11", DataRegistro = dataRegistro},
                new Candidato {Codigo = 12 ,Nome = "Prefeito 12", Partido= "C", Vice = "Vice 12", DataRegistro = dataRegistro},
                new Candidato {Codigo = 13 ,Nome = "Prefeito 13", Partido= "D", Vice = "Vice 13", DataRegistro = dataRegistro},
                new Candidato {Codigo = 14 ,Nome = "Prefeito 14", Partido= "E", Vice = "Vice 14", DataRegistro = dataRegistro},
                new Candidato {Codigo = 15, Nome = "Prefeito 15", Partido= "F", Vice = "Vice 15", DataRegistro = dataRegistro},
                new Candidato {Codigo = 123, Nome = "Prefeito 123", Partido= "G", Vice = "Vice 123", DataRegistro = dataRegistro},
            };
            foreach (Candidato c in candidatos)
            {
                contexto.Candidatos.Add(c);
            }
            contexto.SaveChanges();

            // Adicionando votos ficticios
            DateTime dataVotacao = new DateTime(2021, 8, 13);
            Voto[] votos = new Voto[]
            {
                new Voto {CandidatoId = 10, Data = dataVotacao}, new Voto {CandidatoId = 10, Data = dataVotacao}, new Voto {CandidatoId = 10, Data = dataVotacao},
                new Voto {CandidatoId = 11, Data = dataVotacao},
                new Voto {CandidatoId = 12, Data = dataVotacao}, new Voto {CandidatoId = 12, Data = dataVotacao}, new Voto {CandidatoId = 12, Data = dataVotacao},
                new Voto {CandidatoId = 12, Data = dataVotacao}, new Voto {CandidatoId = 12, Data = dataVotacao}, new Voto {CandidatoId = 12, Data = dataVotacao},
                new Voto {CandidatoId = 13, Data = dataVotacao}, new Voto {CandidatoId = 13, Data = dataVotacao}, new Voto {CandidatoId = 13, Data = dataVotacao},
                new Voto {CandidatoId = 13, Data = dataVotacao}, new Voto {CandidatoId = 13, Data = dataVotacao}, new Voto {CandidatoId = 13, Data = dataVotacao},
                new Voto {CandidatoId = 13, Data = dataVotacao}, new Voto {CandidatoId = 13, Data = dataVotacao}, new Voto {CandidatoId = 13, Data = dataVotacao},
                new Voto {CandidatoId = 14, Data = dataVotacao}, new Voto {CandidatoId = 14, Data = dataVotacao}, new Voto {CandidatoId = 14, Data = dataVotacao},
                new Voto {CandidatoId = 14, Data = dataVotacao}, new Voto {CandidatoId = 14, Data = dataVotacao}, new Voto {CandidatoId = 14, Data = dataVotacao},
                new Voto {CandidatoId = 14, Data = dataVotacao}, new Voto {CandidatoId = 14, Data = dataVotacao}, new Voto {CandidatoId = 14, Data = dataVotacao},
                new Voto {CandidatoId = 14, Data = dataVotacao}, new Voto {CandidatoId = 14, Data = dataVotacao}, new Voto {CandidatoId = 14, Data = dataVotacao},
            };
            foreach (Voto v in votos)
            {
                contexto.Votos.Add(v);
            }
            contexto.SaveChanges();
        }
    }
}
