using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(citasID), Name = "IX_cod_verificacion_citasID")]
    public partial class cod_verificacion
    {
        [Key]
        public int citasID { get; set; }
        [Key]
        [StringLength(10)]
        public string value { get; set; }

        [ForeignKey(nameof(citasID))]
        [InverseProperty("cod_verificacion")]
        public virtual citas citas { get; set; }
    }
}
