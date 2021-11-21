using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class seguros
    {
        public seguros()
        {
            citas = new HashSet<citas>();
            cobertura_analisis = new HashSet<cobertura_analisis>();
         }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(60)]
        public string descrip { get; set; }

        [InverseProperty("seguros")]
        public virtual ICollection<citas> citas { get; set; }
        [InverseProperty("seguros")]
        public virtual ICollection<cobertura_analisis> cobertura_analisis { get; set; }
        [InverseProperty("seguros")]
        public virtual ICollection<cobertura_medicos> cobertura_medicos { get; set; }
    }
}
