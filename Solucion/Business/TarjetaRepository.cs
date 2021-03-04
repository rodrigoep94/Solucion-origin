using Solucion.Data;
using Solucion.Interfaces;
using Solucion.Model;
using Solucion.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Business
{
    public class TarjetaRepository : DataRepository<Model.Tarjeta, DataContext>, ITarjetaRepository
    {
        private IBalanceRepository balanceRepository;

        public TarjetaRepository(DataContext context, IBalanceRepository balanceRepository) : base(context)
        {
            this.balanceRepository = balanceRepository;
        }

        public void BloquearTarjeta(long numeroTarjeta)
        {
            var tarjeta = this.GetByNumeroTarjeta(numeroTarjeta);

            if (tarjeta != null)
            {
                tarjeta.Bloqueada = true;
                this.Update(tarjeta);
            }
            else
            {
                throw new Exception("No existe una tarjeta con el número ingresado en el sistema.");
            }
        }

        public BalanceDto ObtenerBalance(long numeroTarjeta)
        {
            var tarjeta = this.GetByNumeroTarjeta(numeroTarjeta);


            if (tarjeta != null)
            {
                var modelo = new BalanceDto()
                {
                    CantidadEnCuenta = tarjeta.Monto,
                    FechaVencimiento = tarjeta.FechaVencimiento,
                    NumeroTarjeta = tarjeta.Numero
                };

                this.balanceRepository.GenerarBalance(tarjeta.Id);

                return modelo;
            }
            else
            {
                throw new Exception("No existe una tarjeta con el número ingresado en el sistema.");
            }
        }

        public bool ValidarPin(ValidacionPinDto model)
        {
            var tarjeta = this.GetByNumeroTarjeta(model.NumeroTarjeta);

            if (tarjeta != null)
            {
                return tarjeta.Pin == model.NumeroPin;
            }
            else
            {
                throw new Exception("No existe una tarjeta con el número ingresado en el sistema.");
            }
        }

        public bool VerificarExistenciaDeTarjeta(long numeroTarjeta)
        {
            var tarjeta = this.GetByNumeroTarjeta(numeroTarjeta);

            if (tarjeta != null)
            {
                if (tarjeta.Bloqueada)
                {
                    throw new Exception("La tarjeta ingresada se encuentra bloqueada.");
                }
                return true;
            }
            else
            {
                throw new Exception("No existe una tarjeta con el número ingresado en el sistema.");
            }
        }

        public Tarjeta GetByNumeroTarjeta(long numeroTarjeta)
        {
            return this.GetAll().Where(x => x.Numero == numeroTarjeta).FirstOrDefault();
        }
    }
}
