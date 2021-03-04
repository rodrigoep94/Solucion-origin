using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solucion.Model;
using Solucion.Model.DTO;

namespace Solucion.Interfaces
{
    public interface ITarjetaRepository : IRepository<Model.Tarjeta>
    {
        bool VerificarExistenciaDeTarjeta(long numeroTarjeta);

        bool ValidarPin(ValidacionPinDto model);

        void BloquearTarjeta(long numeroTarjeta);

        BalanceDto ObtenerBalance(long numeroTarjeta);

        Tarjeta GetByNumeroTarjeta(long numeroTarjeta);
    }
}
