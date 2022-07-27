using Application.Data.Converters.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Data.DataTransferObjects.Candidates
{
    public class CandidateResponseDto
    {
        public int CandidateId { get; set; }
        public string FullName { get; set; }
        public string ViceName { get; set; }
        public int Legend { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
