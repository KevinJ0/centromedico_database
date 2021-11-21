using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class dias_feriados
    {
        [Key]
        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }
        [Required]
        [StringLength(200)]
        public string descripcion { get; set; }
        [Required]
        [StringLength(50)]
        public string tipo { get; set; }
    }
}
