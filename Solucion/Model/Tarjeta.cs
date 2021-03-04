using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Model
{
    public class Tarjeta : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long Numero { get; set; }

        public int Pin { get; set; }

        public bool Bloqueada { get; set; }

        public double Monto { get; set; }

        public DateTime FechaVencimiento { get; set; }
    }
}
