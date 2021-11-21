using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(analisisID), Name = "IX_pruebas_analisisID")]
    [Index(nameof(resultadosID), Name = "IX_pruebas_resultadosID")]
    public partial class pruebas
    {
        [Key]
        public int ID { get; set; }
        public int analisisID { get; set; }
        [Column(TypeName = "date")]
        public DateTime? fecha_recoleccion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fecha_emision { get; set; }
        public int resultadosID { get; set; }
        public string url { get; set; }
        [StringLength(120)]
        public string nota { get; set; }
        [Column(TypeName = "money")]
        public decimal costo { get; set; }
        public byte? cobertura { get; set; }
        [Column(TypeName = "money")]
        public decimal total { get; set; }
        public int? segurosID { get; set; }
        public bool estado { get; set; }

        [ForeignKey(nameof(analisisID))]
        [InverseProperty("pruebas")]
        public virtual analisis analisis { get; set; }
        [ForeignKey(nameof(resultadosID))]
        [InverseProperty("pruebas")]
        public virtual resultados resultados { get; set; }
    }
}
