using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centromedico.Database.DbModels
{
    [Index(nameof(UserName), Name = "Unique_username", IsUnique = true)]
    public class MyIdentityUser : IdentityUser
    {

        public MyIdentityUser()
        {
         //   grupo_doctor_secretaria = new HashSet<grupo_doctor_secretaria>();

        }
        [InverseProperty("MyIdentityUsers")]
        public virtual ICollection<secretarias> secretarias { get; set; }
        [InverseProperty("MyIdentityUsers")]
        public virtual ICollection<medicos> medicos { get; set; }
        [InverseProperty("MyIdentityUsers")]
        public virtual ICollection<clientes> clientes { get; set; }
        [InverseProperty("MyIdentityUsers")]
        public virtual ICollection<pacientes> pacientes { get; set; }
        //[InverseProperty("MyIdentityUsers")]
        //public virtual ICollection<grupo_doctor_secretaria> grupo_doctor_secretaria { get; set; }


        [StringLength(15)]
        public string doc_identidad { get; set; }
        [StringLength(50)]
        public string nombre { get; set; }
        [StringLength(50)]
        public string apellido { get; set; }
        [StringLength(1)]
        public string sexo { get; set; }
        [StringLength(15)]
        public string contacto { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public bool confirm_doc_identidad { set; get; }

        public string Notes { get; set; }
        public int Type { get; set; }
        /*[Required(ErrorMessage = "Email is required")]
        
        [EmailAddress]
        public string Email { get; set; }
   */
        public string DisplayName { get; set; }
         public virtual List<token> tokens { get; set; }

    }

}
