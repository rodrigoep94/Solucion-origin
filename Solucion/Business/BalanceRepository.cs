using Solucion.Data;
using Solucion.Interfaces;
using Solucion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Business
{
    public class BalanceRepository : DataRepository<Model.Balance, DataContext>, IBalanceRepository
    {

        public BalanceRepository(DataContext context) : base(context)
        {
        }

        public void GenerarBalance(int idTarjeta)
        {
            var balanceAInsertar = new Balance()
            {
                FechaBalance = DateTime.Now,
                TarjetaId = idTarjeta
            };

            this.Add(balanceAInsertar);
        }
    }
}
