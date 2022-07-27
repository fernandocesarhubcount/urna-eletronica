using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.DataTransferObjects.Candidates
{
    public class CandidateRequestDto
    {
        public string FullName { get; set; }
        public string ViceName { get; set; }
        public int Legend { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
