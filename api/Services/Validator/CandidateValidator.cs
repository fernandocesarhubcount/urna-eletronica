using System;
using api.Models;

namespace api.Services.Validator
{
    public class CandidateValidator
    {
        public void Validate(Candidate candidate)
        {
            if (String.IsNullOrEmpty(candidate.FullName))
                throw new Exception("O nome do candidato é obrigatório.");

            if (String.IsNullOrEmpty(candidate.ViceFullName))
                throw new Exception("O nome do vice é obrigatório.");

            if (candidate.Legend == 0)
                throw new Exception("A legenda é obrigatória.");

            if (candidate.Legend.ToString().Length != 2)
                throw new Exception("A legenda deve ter dois digitos");
        }
    }
}