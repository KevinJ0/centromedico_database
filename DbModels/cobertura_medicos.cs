using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(segurosID))]
    public partial class cobertura_medicos
    {
        [Key]
        public int medicosID { get; set; }
        public byte porciento { get; set; }
        [Key]
        public int segurosID { get; set; }
        public int serviciosID { get; set; }
        [Column(TypeName = "money")]
        public decimal pago { get; set; }

        [ForeignKey(nameof(medicosID))]
        [InverseProperty("cobertura_medicos")]
        public virtual medicos medicos { get; set; }
        [ForeignKey(nameof(segurosID))]
        [InverseProperty("cobertura_medicos")]
        public virtual seguros seguros { get; set; }
        [ForeignKey(nameof(serviciosID))]
        [InverseProperty("cobertura_medicos")]
        public virtual servicios servicios { get; set; }
    }
}
