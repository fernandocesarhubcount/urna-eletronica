using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Urna.Core;
using Microsoft.EntityFrameworkCore;

namespace Urna.Data
{
    public class SqlUrnaData : IUrnaData
    {
        private UrnaDbContext db;

        public SqlUrnaData(UrnaDbContext db)
        {
            this.db = db;
        }

        public Candidate GetCandidateById(int? id)
        {
            if (id == null)
                return null;
            return db.Candidates.Find(id);
        }

        public Candidate GetCandidateByLegenda(int? legenda)
        {
            return db.Candidates.SingleOrDefault(c => c.Legenda == legenda);
        }

        public Candidate AddCandidate(Candidate newCandidate)
        {
            db.Candidates.Add(newCandidate);
            return newCandidate;
        }

        public Candidate DeleteCandidate(Candidate Candidate)
        {
            db.Candidates.Remove(Candidate);
            return Candidate;

        }

        public IEnumerable<Candidate> GetCandidatesByVote()
        {
            /* Opção Funcional:
             * 1) Utiliza uma chamada ao context para receber a lista de candidatos.
             * 2) Realiza outra chamada para receber a lista de votos de cada candidato, e armazena num dicionário.
             * 3) Junta ambos em um só objeto.
             */

            var candidatosInfo = db.Candidates.ToList();
            var candidatosVoto = (from v in db.Votes
                                 group v by v.CandidateId into g
                                 select new Candidate
                                 {
                                     CandidateId = (int) g.Key,
                                     QtdVotos = g.Count()
                                 }).ToDictionary(x => x.CandidateId);

            foreach (var c in candidatosInfo)
            {
                c.QtdVotos = candidatosVoto.ContainsKey(c.CandidateId) ? candidatosVoto[c.CandidateId].QtdVotos : 0;
            }

            return candidatosInfo.OrderByDescending(x => x.QtdVotos);  // Retorna dados em ordem do mais votado par o menos votado.

            // Alternativa 1: Ideal. Query de Linq que efetua um left outer join.
            // Código abaixo faz um inner join. Necessitaria ser um left join (para incluir valores de 0).
            /*
            var query = from c in db.Candidates
                        join v in db.Votes on c.CandidateId equals v.CandidateId
                        group v by v.CandidateId into g
                        select new {
                            Id = g.Key,
                            Count = g.Count()
                        };
            */

            // Opção 2 (Pior): Executar um RawSql. Até funciona, mas devido a anotação [NotMapped] associada a QtdVotos, ela nunca é retornada
            // Para funcionar exigiria remover 
            /*
            var Candidatos = db.Candidates
              .FromSqlRaw(@"SELECT c.CandidateId, c.Nome, c.NomeVice, c.DataRegistro, c.Legenda, null As 'Votos', count(v.VoteId) As 'QtdVotos'
                            FROM candidates c
                            LEFT JOIN votes v ON c.CandidateId = v.CandidateId
                            GROUP BY c.CandidateId
                            ORDER BY count(v.VoteId) DESC; ").ToList();
            */
        }

        public Vote AddVote(Vote newVote)
        {
            db.Votes.Add(newVote);
            return newVote;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
