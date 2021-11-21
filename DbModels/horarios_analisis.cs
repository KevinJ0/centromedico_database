using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class horarios_analisis
    {
        [Key]
        public int analisisID { get; set; }
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
        
        [ForeignKey(nameof(analisisID))]
        [InverseProperty("horarios_analisis")]
        public virtual analisis analisis { get; set; }
    }
}
