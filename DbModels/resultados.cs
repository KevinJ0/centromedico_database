using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(clientesID), Name = "IX_resultados_clientesID")]
    [Index(nameof(medicosID), Name = "IX_resultados_medicosID")]
    public partial class resultados
    {
        public resultados()
        {
            pruebas = new HashSet<pruebas>();
        }

        [Key]
        public int ID { get; set; }
        public int clientesID { get; set; }
        [Column(TypeName = "date")]
        public DateTime? fecha_entrada { get; set; }
        [Column(TypeName = "date")]
        public DateTime? fecha_reporte { get; set; }
        public bool estado { get; set; }
        public int? medicosID { get; set; }
        [Column(TypeName = "money")]
        public decimal? total { get; set; }

        [ForeignKey(nameof(clientesID))]
        [InverseProperty("resultados")]
        public virtual clientes clientes { get; set; }
        [ForeignKey(nameof(medicosID))]
        [InverseProperty("resultados")]
        public virtual medicos medicos { get; set; }
        [InverseProperty("resultados")]
        public virtual ICollection<pruebas> pruebas { get; set; }
    }
}
