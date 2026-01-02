using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class grupo_doctor_secretaria
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(450)]
        public string group_name { get; set; }
        [Required]
        [StringLength(50)]
        public string type { get; set; }
        //[Required]
        //[StringLength(450)]
        //public string MyIdentityUserID { get; set; }
        public int medicosID { get; set; }
        /*
        [ForeignKey(nameof(MyIdentityUserID))]
        [InverseProperty("grupo_doctor_secretaria")]
        public virtual MyIdentityUser? MyIdentityUsers { get; set; }*/

        [ForeignKey(nameof(medicosID))]
        [InverseProperty("grupo_doctor_secretaria")]
        public virtual medicos medicos { get; set; }
    }
}
