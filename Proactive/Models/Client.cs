using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proactive.Models
{
    public class Client
    {
        public int Codigo { get; set; }
        public int Cuenta { get; set; }
        public string Nombre { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
    }
}