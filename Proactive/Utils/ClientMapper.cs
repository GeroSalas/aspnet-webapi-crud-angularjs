using Proactive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proactive.Utils
{
    public class ClientMapper
    {
        // Target Model <----> Source Entity

        public static List<Client> convertEntitytoDTOs(List<Cliente> clientes)
        {
            List<Client> clients = new List<Client>();
            foreach(Cliente c in clientes)
            {
                Client dto = convertEntitytoDTO(c);
                clients.Add(dto);
            }

            return clients;
        }

        public static Client convertEntitytoDTO(Cliente cliente)
        {
            Client dto = new Client();
            dto.Codigo = cliente.codigo;
            dto.Nombre = cliente.nombre_cliente;
            dto.Cuenta = cliente.numero_cuenta;
            dto.State = new State();
            dto.State.Codigo = cliente.Estado.codigo;
            dto.State.Nombre = cliente.Estado.nombre;
            dto.Country = new Country();
            dto.Country.Codigo = cliente.Pais.codigo;
            dto.Country.Nombre = cliente.Pais.nombre;

            return dto;
        }

        public static Cliente matchDTOtoEntity(Client dto)
        {
            Cliente entity = new Cliente();
            //entity.codigo = dto.Codigo;
            entity.nombre_cliente = dto.Nombre;
            entity.numero_cuenta = dto.Cuenta;
            entity.codigo_estado = dto.State.Codigo;
            entity.codigo_pais = dto.Country.Codigo;
            return entity;
        }

    }
}