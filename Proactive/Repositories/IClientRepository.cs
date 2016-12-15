using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proactive.Repositories
{
    interface IClientRepository
    {
        IEnumerable<Cliente> GetAll();
        Cliente Get(int id);
        Cliente Add(Cliente item);
        bool Update(Cliente item);
        bool Delete(int id);
    }
}
