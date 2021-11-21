using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(analisis_categoriaID), Name = "IX_analisis_analisis_categoriaID")]
    public partial class analisis
    {
        public analisis()
        {
            cobertura_analisis = new HashSet<cobertura_analisis>();
            pruebas = new HashSet<pruebas>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string descrip { get; set; }
        public int analisis_categoriaID { get; set; }
        [Column(TypeName = "money")]
        public decimal costo { get; set; }
        [Column(TypeName = "text")]
        public string condicion_paciente { get; set; }
        [Column(TypeName = "text")]
        public string condicion_muestra { get; set; }
        [Column(TypeName = "text")]
        public string dias_procesa { get; set; }

        [ForeignKey(nameof(analisis_categoriaID))]
        [InverseProperty("analisis")]
        public virtual analisis_categoria analisis_categoria { get; set; }
        [InverseProperty("analisis")]
        public virtual horarios_analisis horarios_analisis { get; set; }
        [InverseProperty("analisis")]
        public virtual ICollection<cobertura_analisis> cobertura_analisis { get; set; }
        [InverseProperty("analisis")]
        public virtual ICollection<pruebas> pruebas { get; set; }
    }
}
