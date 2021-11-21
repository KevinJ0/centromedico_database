using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class servicios
    {
        public servicios()
        {
            servicios_medicos = new HashSet<servicios_medicos>();
            citas = new HashSet<citas>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(40)]
        public string descrip { get; set; }
      

      
        [InverseProperty("servicios")]
        public virtual ICollection<citas> citas { get; set; }
        [InverseProperty("servicios")]
        public virtual ICollection<cobertura_medicos> cobertura_medicos { get; set; }
        [InverseProperty("servicios")]
        public virtual ICollection<servicios_medicos> servicios_medicos { get; set; }
    }
}
