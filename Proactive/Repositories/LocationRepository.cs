using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proactive.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        // Data Access Object
        ProactiveDBEntities db = new ProactiveDBEntities();

        public IEnumerable<Estado> GetAllEstadosByPais(int id)
        {
            return db.Estado.Where(e => e.codigo_pais == id);
        }

        public IEnumerable<Pais> GetAllPaises()
        {
            return db.Pais;
        }
    }
}