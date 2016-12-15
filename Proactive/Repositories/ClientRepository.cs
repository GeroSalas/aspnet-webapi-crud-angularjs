using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proactive.Repositories
{
    public class ClientRepository : IClientRepository
    {
        // Data Access Object
        ProactiveDBEntities db = new ProactiveDBEntities();
    
        public Cliente Get(int id)
        {
            return db.Cliente.Find(id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return db.Cliente;
        }

        public Cliente Add(Cliente item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Cliente");
            }

            db.Cliente.Add(item);
            db.Entry(item).State = EntityState.Added;
            db.SaveChanges();

            db.Entry(item).Reload();
            db.Entry(item).State = EntityState.Detached;

            return item;
        }

        public bool Update(Cliente item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Cliente");
            }

            var client = db.Cliente.Single(c => c.codigo == item.codigo);
            client.nombre_cliente = item.nombre_cliente;
            client.codigo_estado = item.codigo_estado;
            client.codigo_pais = item.codigo_pais;

            db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            Cliente c = db.Cliente.Find(id);
            db.Cliente.Remove(c);
            db.Entry(c).State = EntityState.Deleted;
            db.SaveChanges();

            return true;
        }

    }

}