using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(secretariasID), Name = "IX_secretarias_medicos_secretariasID")]
    public partial class secretarias_medicos
    {
        [Key]
        public int secretariasID { get; set; }
        [Key]
        public int medicosID { get; set; }

        [ForeignKey(nameof(medicosID))]
        [InverseProperty("secretarias_medicos")]
        public virtual medicos medicos { get; set; }

        [ForeignKey(nameof(secretariasID))]
        [InverseProperty("secretarias_medicos")]
        public virtual secretarias secretarias { get; set; }
    }
}
