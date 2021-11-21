using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(descrip), Name = "unique_descrip", IsUnique = true)]
    public partial class analisis_categoria
    {
        public analisis_categoria()
        {
            analisis = new HashSet<analisis>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string descrip { get; set; }
        [Required]
        public bool? estados { get; set; }

        [InverseProperty("analisis_categoria")]
        public virtual ICollection<analisis> analisis { get; set; }
    }
}
