using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    [Index(nameof(MyIdentityUserID), Name = "IX_clientes_MyIdentityUserID")]
    [Index(nameof(doc_identidad), Name = "unique_identidad", IsUnique = true)]
    public partial class clientes
    {
        public clientes()
        {
            resultados = new HashSet<resultados>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(15)]
        public string doc_identidad { get; set; }
        public bool extranjero { get; set; }
        public string MyIdentityUserID { get; set; }
        [Required]
        [StringLength(40)]
        public string nombre { get; set; }
        [StringLength(50)]
        public string apellido { get; set; }

        [ForeignKey(nameof(MyIdentityUserID))]
        [InverseProperty(nameof(MyIdentityUser.clientes))]
        public virtual MyIdentityUser MyIdentityUsers { get; set; }
        [InverseProperty("clientes")]
        public virtual ICollection<resultados> resultados { get; set; }
    }
}
