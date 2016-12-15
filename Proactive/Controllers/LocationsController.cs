using Proactive.Models;
using Proactive.Repositories;
using Proactive.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proactive.Controllers
{
    [RoutePrefix("api")]
    public class LocationsController : ApiController
    {
        static readonly ILocationRepository repository = new LocationRepository();


        [HttpGet]
        [Route("countries")]
        public List<Country> Countries()
        {
            List<Country> countries = LocationMapper.convertEntitytoDTOs(repository.GetAllPaises().ToList());
            return countries;
        }

        
        [HttpGet]
        [Route("states/{countryId}")]
        public List<State> States(int countryId)
        {
            List<State> states = LocationMapper.convertEntitytoDTOs(repository.GetAllEstadosByPais(countryId).ToList());
            return states;
        }
        

    }
}