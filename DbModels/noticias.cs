using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class noticias
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(80)]
        public string encabezado { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Contenido { get; set; }
        [Column(TypeName = "date")]
        public DateTime fecha_creacion { get; set; }
        [Column(TypeName = "image")]
        public byte[] img_titulo { get; set; }
        [StringLength(30)]
        public string lugar { get; set; }
        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }
        [Required]
        public bool? estado { get; set; }
    }
}
