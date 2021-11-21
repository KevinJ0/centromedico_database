using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class horarios_medicos
    {
        [Key]
        public int medicosID { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan tiempo_cita { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? monday_from { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? monday_until { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? tuesday_from { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? tuesday_until { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? wednesday_from { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? wednesday_until { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? thursday_from { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? thursday_until { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? friday_from { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? friday_until { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? saturday_from { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? saturday_until { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? sunday_from { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? sunday_until { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? free_time_from { get; set; }
        [Column(TypeName = "time(4)")]
        public TimeSpan? free_time_until { get; set; }

        [ForeignKey(nameof(medicosID))]
        [InverseProperty("horarios_medicos")]
        public virtual medicos medicos { get; set; }
    }
}
