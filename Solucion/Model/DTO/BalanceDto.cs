using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Model.DTO
{
    public class BalanceDto
    {
        public long NumeroTarjeta { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public double CantidadEnCuenta { get; set; }
    }
}
