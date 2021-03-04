using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Model
{
    public class Retiro : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Tarjeta Tarjeta { get; set; }

        public virtual int TarjetaId { get; set; }

        public DateTime FechaRetiro { get; set; }

        public double Monto { get; set; }
    }
}
