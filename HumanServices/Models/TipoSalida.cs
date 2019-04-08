using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanServices.Models
{
    public class TipoSalida
    {
        public int TipoSalidaId { get; set; }
        public string TipoSalidas { get; set; }

        public ICollection<Salidas> Salidas { get; set; }

    }
}