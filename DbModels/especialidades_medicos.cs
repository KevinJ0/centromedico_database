using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class especialidades_medicos
    {
        [Key]
        public int especialidadesID { get; set; }
        [Key]
        public int medicosID { get; set; }

        [ForeignKey(nameof(especialidadesID))]
        [InverseProperty("especialidades_medicos")]
        public virtual especialidades especialidades { get; set; }
        [ForeignKey(nameof(medicosID))]
        [InverseProperty("especialidades_medicos")]
        public virtual medicos medicos { get; set; }
    }
}
