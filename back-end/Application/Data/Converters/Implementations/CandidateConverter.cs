using Application.Data.Converters.Interfaces;
using Application.Data.DataTransferObjects.Candidates;
using Model.Entities;

namespace Application.Data.Converters
{
    public class CandidateConverter : IConverter<Candidate, CandidateRequestDto, CandidateResponseDto>
    {
        public Candidate RequestToModel(CandidateRequestDto dtoRequest)
        {
            return new()
            {
                FullName = dtoRequest.FullName,
                ViceName = dtoRequest.ViceName,
                Legend = dtoRequest.Legend,
                RegisterDate = dtoRequest.RegisterDate,
            };
        }

        public CandidateResponseDto ModelToResponse(Candidate model)
        {
            return new()
            {
                CandidateId = model.Id,
                FullName = model.FullName,
                ViceName = model.ViceName,
                Legend = model.Legend,
                RegisterDate = model.RegisterDate,
            };
        }
    }
}
