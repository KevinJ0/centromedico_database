using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    // [Index(nameof(doc_identidad), Name = "unique_docIdentidad", IsUnique = true)]
    public partial class pacientes
    {

        public pacientes()
        {
            citas = new HashSet<citas>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(40)]
        public string nombre { get; set; }
        [StringLength(50)]
        public string apellido { get; set; }
        [Required]
        [StringLength(1)]
        public string sexo { get; set; }
        [Column(TypeName = "date")]
        public DateTime fecha_nacimiento { get; set; }
        [StringLength(15)]
        public string doc_identidad { get; set; }
        [StringLength(40)]
        public string nombre_tutor { get; set; }
        [StringLength(45)]
        public string apellido_tutor { get; set; }
        public bool extranjero { get; set; }
        [StringLength(10)]
        public string contacto { get; set; }
        [StringLength(15)]
        public string doc_identidad_tutor { get; set; }
        //  public int? edad {get;set;}
        public bool menor_un_año { get; set; }
        public string MyIdentityUserID { get; set; }

        [InverseProperty("pacientes")]
        public virtual ICollection<citas> citas { get; set; }
        [ForeignKey(nameof(MyIdentityUserID))]
        [InverseProperty(nameof(MyIdentityUser.pacientes))]
        public virtual MyIdentityUser MyIdentityUsers { get; set; }
    }
}
