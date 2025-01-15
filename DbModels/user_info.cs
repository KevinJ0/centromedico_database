using System;
using System.ComponentModel.DataAnnotations;

namespace Centromedico.Database
{
    public class user_info
    {
        [StringLength(15)]
        [Required]
        public string doc_identidad { get; set; }
        [StringLength(50)]
        [Required]
        public string nombre { get; set; }
        [StringLength(50)]
        [Required]
        public string apellido { get; set; }
        [StringLength(1)]
        [Required]
        public string sexo { get; set; }
        [StringLength(15)]
        public string contacto { get; set; }
        [Required]
        public DateTime fecha_nacimiento { get; set; }

        public string email { get; set; }

    }
}
