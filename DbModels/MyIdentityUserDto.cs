using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centromedico.Database.DbModels
{
    public class MyIdentityUserDto 
    {

        public MyIdentityUserDto()
        {

        }


        [StringLength(15)]
        public string doc_identidad { get; set; }
        [StringLength(50)]
        public string nombre { get; set; }
        [StringLength(50)]
        public string apellido { get; set; }
        [StringLength(1)]
        public string sexo { get; set; }
        [EmailAddress]
        public string email { get; set; }

        [StringLength(15)]
        public string contacto { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public bool confirm_doc_identidad { set; get; }

        public string Notes { get; set; }
        public string DisplayName { get; set; }

    }

}
