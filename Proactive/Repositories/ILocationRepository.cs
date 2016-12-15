using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proactive.Repositories
{
    interface ILocationRepository
    {
        IEnumerable<Pais> GetAllPaises();
        IEnumerable<Estado> GetAllEstadosByPais(int id);
    }
}
