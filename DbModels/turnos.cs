using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class turnos
    {

        [Key]
        public int medicosID { get; set; }
        public int turno_actual { get; set; }
        public int turno_atendido { get; set; }
        public DateTime fecha { get; set; }


        [ForeignKey(nameof(medicosID))]
        [InverseProperty("turnos")]
        public virtual medicos medicos { get; set; }
    }
}
