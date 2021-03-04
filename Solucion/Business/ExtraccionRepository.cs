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
    public class ExtraccionRepository : DataRepository<Model.Retiro, DataContext>, IExtraccionRepository
    {
        private ITarjetaRepository tarjetaRepository;

        public ExtraccionRepository(DataContext context, ITarjetaRepository tarjetaRepository) : base(context)
        {
            this.tarjetaRepository = tarjetaRepository;
        }

        public Retiro GetRetiroFullEntity(int id)
        {
            var retiro = this.Get(id);

            if (retiro != null)
            {
                retiro.Tarjeta = this.tarjetaRepository.Get(retiro.TarjetaId);
                return retiro;
            }

            throw new Exception($"No existe un retiro con el id {id}");
        }

        public Retiro Extraer(ExtraccionDto model)
        {
            var tarjeta = this.tarjetaRepository.GetByNumeroTarjeta(model.NumeroTarjeta);

            if(tarjeta != null)
            {
                if (tarjeta.Monto < model.Monto)
                {
                    throw new Exception("El monto a extraer excede el monto actual de la tarjeta.");
                }
                else
                {
                    var nuevoRetiro = new Retiro()
                    {
                        Monto = model.Monto,
                        FechaRetiro = DateTime.Now,
                        TarjetaId = tarjeta.Id
                    };

                    var retiroAgregado = this.Add(nuevoRetiro);

                    tarjeta.Monto -= model.Monto;

                    this.tarjetaRepository.Update(tarjeta);

                    return retiroAgregado;
                }
            }
            else
            {
                throw new Exception("La tarjeta no existe en el sistema.");
            }
        }
    }
}
