using System;
using System.Collections.Generic;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class horarios_medicos_reservados
    {
        public int medicosID { get; set; }
        //public byte? turno { get; set; }
        public DateTime fecha_hora { get; set; }
    }
}
