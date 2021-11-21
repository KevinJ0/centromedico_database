using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(MyIdentityUserID), Name = "IX_secretarias_MyIdentityUserID")]
    public partial class secretarias
    {
        public secretarias()
        {
            balance_caja = new HashSet<balance_caja>();
            citas = new HashSet<citas>();
            secretarias_medicos = new HashSet<secretarias_medicos>();
        }

        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string correo { get; set; }
        [Required]
        [StringLength(40)]
        public string nombre { get; set; }
        [StringLength(50)]
        public string apellido { get; set; }
        [Column(TypeName = "date")]
        public DateTime? fecha_creacion { get; set; }
        [Required]
        public bool? estado { get; set; }
        public string MyIdentityUserID { get; set; }

        [ForeignKey(nameof(MyIdentityUserID))]
        [InverseProperty(nameof(MyIdentityUser.secretarias))]
        public virtual MyIdentityUser MyIdentityUsers { get; set; }
        [InverseProperty("secretarias")]
        public virtual ICollection<balance_caja> balance_caja { get; set; }
        [InverseProperty("secretarias")]
        public virtual ICollection<citas> citas { get; set; }
        [InverseProperty("secretarias")]
        public virtual ICollection<secretarias_medicos> secretarias_medicos { get; set; }
    }
}
