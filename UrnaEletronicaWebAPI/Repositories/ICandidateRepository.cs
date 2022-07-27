using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronicaWebAPI.Models;

namespace UrnaEletronicaWebAPI.Repositories
{
    public interface ICandidateRepository
    {
        Candidate AddCandidate(Candidate candidate);
 
        Candidate GetCandidateByLegenda(int? legenda); 

        void DeleteCandidateByLegenda(int legenda);
    }
}