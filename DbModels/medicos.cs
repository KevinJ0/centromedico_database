using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(MyIdentityUserID), Name = "IX_medicos_MyIdentityUserID")]
    public partial class medicos
    {
        public medicos()
        {
            balance_caja = new HashSet<balance_caja>();
            citas = new HashSet<citas>();
            cobertura_medicos = new HashSet<cobertura_medicos>();
            especialidades_medicos = new HashSet<especialidades_medicos>();
            extensiones_telefonicas = new HashSet<extensiones_telefonicas>();
            resultados = new HashSet<resultados>();
            secretarias_medicos = new HashSet<secretarias_medicos>();
        }

        [Key]
        public int ID { get; set; }
        [StringLength(10)]
        public string exequatur { get; set; }
        [Required]
        [StringLength(10)]
        public string colegiatura { get; set; }
        [Required]
        [StringLength(11)]
        public string cedula { get; set; }
        [Required]
        [StringLength(30)]
        public string nombre { get; set; }
        [StringLength(40)]
        [Required]
        public string apellido { get; set; }
        [Required]
        [StringLength(1)]
        public string sexo { get; set; }
        [Column(TypeName = "date")]
        public DateTime? fecha_nacimiento { get; set; }
        [Column(TypeName = "date")]
        public DateTime fecha_creacion { get; set; }
        [StringLength(50)]
        public string correo { get; set; }
        public string url_twitter { get; set; }
        public string url_facebook { get; set; }
        public string url_instagram { get; set; }
        public string MyIdentityUserID { get; set; }
        [StringLength(10)]
        public string telefono1 { get; set; }
        [StringLength(10)]
        public string telefono2 { get; set; }
        public int consultorio { get; set; }
        [Required]
        public bool? estado { get; set; }
        public string ProfilePhoto { get; set; }
        [StringLength(2)]
        public string telefono1_contact { get; set; }
        [StringLength(2)]
        public string telefono2_contact { get; set; }

        [ForeignKey(nameof(MyIdentityUserID))]
        [InverseProperty(nameof(MyIdentityUser.medicos))]
        public virtual MyIdentityUser MyIdentityUsers { get; set; }
        [InverseProperty("medicos")]
        public virtual horarios_medicos horarios_medicos { get; set; }
        [InverseProperty("medicos")]
        public virtual turnos turnos { get; set; }
        [InverseProperty("medicos")]
        public virtual ICollection<balance_caja> balance_caja { get; set; }
        [InverseProperty("medicos")]
        public virtual ICollection<citas> citas { get; set; }
        [InverseProperty("medicos")] 
        public virtual ICollection<cobertura_medicos> cobertura_medicos { get; set; }
        [InverseProperty("medicos")]
        public virtual ICollection<especialidades_medicos> especialidades_medicos { get; set; }
        [InverseProperty("medicos")]
        public virtual ICollection<extensiones_telefonicas> extensiones_telefonicas { get; set; }
        [InverseProperty("medicos")]
        public virtual ICollection<resultados> resultados { get; set; }
        [InverseProperty("medicos")]
        public virtual ICollection<secretarias_medicos> secretarias_medicos { get; set; }
        [InverseProperty("medicos")]
        public virtual ICollection<servicios_medicos> servicios_medicos { get; set; }


    }
}
