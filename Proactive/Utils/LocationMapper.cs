using Proactive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proactive.Utils
{
    public class LocationMapper
    {
        
        // Target Model <----> Source Entity

        public static List<Country> convertEntitytoDTOs(List<Pais> paises)
        {
            List<Country> countries = new List<Country>();
            foreach(Pais p in paises)
            {
                Country dto = convertEntitytoDTO(p);
                countries.Add(dto);
            }

            return countries;
        }

        public static Country convertEntitytoDTO(Pais pais)
        {
            Country dto = new Country();
            dto.Codigo = pais.codigo;
            dto.Nombre = pais.nombre;

            return dto;
        }


        public static List<State> convertEntitytoDTOs(List<Estado> estados)
        {
            List<State> states = new List<State>();
            foreach (Estado e in estados)
            {
                State dto = convertEntitytoDTO(e);
                states.Add(dto);
            }

            return states;
        }

        public static State convertEntitytoDTO(Estado estado)
        {
            State dto = new State();
            dto.Codigo = estado.codigo;
            dto.Nombre = estado.nombre;

            return dto;
        }


    }
}