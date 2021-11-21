using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class especialidades
    {
        public especialidades()
        {
          //  citas = new HashSet<citas>();
            especialidades_medicos = new HashSet<especialidades_medicos>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string descrip { get; set; }
        [Required]
        public bool? estado { get; set; }

     /*   [InverseProperty("especialidades")]
        public virtual ICollection<cobertura_medicos> cobertura_medicos { get; set; }*/
/*        [InverseProperty("especialidades")]
        public virtual ICollection<citas> citas { get; set; }*/
        [InverseProperty("especialidades")]
        public virtual ICollection<especialidades_medicos> especialidades_medicos { get; set; }
    }
}
