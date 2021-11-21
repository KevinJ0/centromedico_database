using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(medicosID), Name = "IX_extensiones_telefonicas_medicosID")]
    public partial class extensiones_telefonicas
    {
        [Key]
        [StringLength(7)]
        public string ID { get; set; }
        public int medicosID { get; set; }

        [ForeignKey(nameof(medicosID))]
        [InverseProperty("extensiones_telefonicas")]
        public virtual medicos medicos { get; set; }
    }
}
