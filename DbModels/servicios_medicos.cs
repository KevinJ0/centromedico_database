using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class servicios_medicos
    {
        [Key]
        public int serviciosID { get; set; }
        [Key]
        public int medicosID { get; set; }

        [ForeignKey(nameof(serviciosID))]
        [InverseProperty("servicios_medicos")]
        public virtual servicios servicios { get; set; }
        [ForeignKey(nameof(medicosID))]
        [InverseProperty("servicios_medicos")]
        public virtual medicos medicos{ get; set; }
    }
}
