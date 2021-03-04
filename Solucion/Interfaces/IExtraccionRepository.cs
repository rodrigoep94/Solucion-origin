using Solucion.Model;
using Solucion.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Interfaces
{
    public interface IExtraccionRepository : IRepository<Model.Retiro>
    {
        Retiro Extraer(ExtraccionDto model);

        Retiro GetRetiroFullEntity(int id);
    }
}
