using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class turnos
    {
        [Key]
        public int medicosID { get; set; }
        public byte turno_atendido { get; set; }

        [ForeignKey(nameof(medicosID))]
        [InverseProperty("turnos")]
        public virtual medicos medicos { get; set; }
    }
}
