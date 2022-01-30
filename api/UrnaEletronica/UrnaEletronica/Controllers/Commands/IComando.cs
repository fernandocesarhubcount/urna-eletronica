using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaEletronica.Controllers.Commands
{
    public interface IComando
    {
        bool Valid();
    }
}
