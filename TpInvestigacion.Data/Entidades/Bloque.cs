using System;
using System.Collections.Generic;

namespace TpInvestigacion.Data.Entidades
{
    public partial class Bloque
    {
        public int Id { get; set; }
        public string? Datos { get; set; }
        public string? Hash { get; set; }
        public string? HashAnterior { get; set; }
        public DateTime? Tiempo { get; set; }
        public bool? Integro { get; set; }
    }
}
