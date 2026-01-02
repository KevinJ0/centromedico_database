using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(cod_verificacionID), Name = "IX_citas_cod_verificacionID")]
   // [Index(nameof(especialidadesID), Name = "IX_citas_especialidadesID")]
    [Index(nameof(medicosID), Name = "IX_citas_medicosID")]
    [Index(nameof(pacientesID), Name = "IX_citas_pacientesID")]
    [Index(nameof(secretariasID), Name = "IX_citas_secretariasID")]
    [Index(nameof(segurosID), Name = "IX_citas_segurosID")]
    [Index(nameof(serviciosID), Name = "IX_citas_serviciosID")]
    public partial class citas
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int medicosID { get; set; }
        public int turno { get; set; }
        [Required] 
        public int serviciosID { get; set; }
        [StringLength(6)]
        public string cod_verificacionID { get; set; }
        public int pacientesID { get; set; }
        public string nota { get; set; }
        [StringLength(10)]
        public string contacto { get; set; }
        [DisplayFormat(NullDisplayText = "Sin especificar")]
        public bool? contacto_whatsapp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fecha_hora { get; set; }
        public int? segurosID { get; set; }
        public int? secretariasID { get; set; }
        [Column(TypeName = "money")]
        public decimal diferencia { get; set; }
        [Column(TypeName = "money")]
        public decimal? cobertura { get; set; }
        [Column(TypeName = "money")]
        public decimal descuento { get; set; }
        [Column(TypeName = "money")]
        public decimal pago { get; set; }
        //public int especialidadesID { get; set; }
        [Required]
        public bool? estado { get; set; }
        public bool deleted { get; set; }
        public int consultorio { get; set; }
        public string observacion { get; set; }
        public DateTime? deleted_date { get; set; } 

        /*[ForeignKey(nameof(especialidadesID))]
         [InverseProperty("citas")]
         public virtual especialidades especialidades { get; set; }*/
        [ForeignKey(nameof(medicosID))]
        [InverseProperty("citas")]
        public virtual medicos medicos { get; set; }
        [ForeignKey(nameof(pacientesID))]
        [InverseProperty("citas")]
        public virtual pacientes pacientes { get; set; }
        [ForeignKey(nameof(secretariasID))]
        [InverseProperty("citas")]
        public virtual secretarias secretarias { get; set; }
        [ForeignKey(nameof(segurosID))]
        [InverseProperty("citas")]
        public virtual seguros seguros { get; set; }
        [ForeignKey(nameof(serviciosID))]
        [InverseProperty(nameof(DbModels.servicios.citas))]
        public virtual servicios servicios { get; set; }
        [InverseProperty("citas")]
        public virtual ICollection<cod_verificacion> cod_verificacion { get; set; }

    }
}
