using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Interfaces
{
    public interface IBalanceRepository : IRepository<Model.Balance>
    {
        void GenerarBalance(int idTarjeta);
    }
}
