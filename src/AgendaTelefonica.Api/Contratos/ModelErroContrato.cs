using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonica.Api.Contratos
{
    public class ModelErroContrato
    {
        public int StatusCode { get; set; }
        public string TituloErro { get; set; }
        public string MensageErro { get; set; }

    }
}