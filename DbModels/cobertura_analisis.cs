using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(segurosID), Name = "IX_cobertura_analisis_segurosID")]
    public partial class cobertura_analisis
    {
        [Key]
        public int analisisID { get; set; }
        public byte? porciento { get; set; }
        [Key]
        public int segurosID { get; set; }

        [ForeignKey(nameof(analisisID))]
        [InverseProperty("cobertura_analisis")]
        public virtual analisis analisis { get; set; }
        [ForeignKey(nameof(segurosID))]
        [InverseProperty("cobertura_analisis")]
        public virtual seguros seguros { get; set; }
    }
}
