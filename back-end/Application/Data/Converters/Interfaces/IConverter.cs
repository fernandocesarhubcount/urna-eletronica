using Application.Data.DataTransferObjects.Candidates;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Converters.Interfaces
{
    public interface IConverter<MODEL,DTOREQUEST,DTORESPONSE>
    {
        public DTORESPONSE ModelToResponse(MODEL model);
        public MODEL RequestToModel(DTOREQUEST dtoRequest);
    }
}
