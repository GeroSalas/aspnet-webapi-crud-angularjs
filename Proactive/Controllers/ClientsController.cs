using Proactive.Models;
using Proactive.Repositories;
using Proactive.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proactive.Controllers
{
    [RoutePrefix("api")]
    public class ClientsController : ApiController
    {

        static readonly IClientRepository repository = new ClientRepository();

        /******************************** CRUD **************************************/

        [HttpGet]
        [Route("clients")]
        public List<Client> List()
        {
            List<Client> clients = ClientMapper.convertEntitytoDTOs(repository.GetAll().ToList());
            return clients;
        }

        [HttpPost]
        [Route("clients")]
        public bool Create(Client item)
        {
            Cliente client = ClientMapper.matchDTOtoEntity(item);
            repository.Add(client);
            return true;
        }

        [HttpPut]
        [Route("clients/{clientId}")]
        public bool Update(int clientId, Client req)
        {
            Cliente client = ClientMapper.matchDTOtoEntity(req);
            client.codigo = clientId;

            if (repository.Update(client))
            {
                return true;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        [Route("clients/{clientId}")]
        public bool Delete(int clientId)
        {
            if (repository.Delete(clientId))
            {
                return true;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

    }
}
