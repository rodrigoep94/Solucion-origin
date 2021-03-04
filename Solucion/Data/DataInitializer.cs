using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Solucion.Data
{
    public class DataInitializer
    {
        public static void Initialize(DataContext context)
        {
            using (context)
            {
                context.Database.EnsureCreated();
                if (context.Tarjeta.Any())
                {
                    return; 
                }

                context.Tarjeta.AddRange(
                    new Model.Tarjeta
                    {
                        Numero = 5378765412348723,
                        Bloqueada = false,
                        Monto = 456284,
                        Pin = 1234,
                        FechaVencimiento = new DateTime(2023, 4, 2)
                    },

                    new Model.Tarjeta
                    {
                        Numero = 1234123412341234,
                        Bloqueada = false,
                        Monto = 123123123123,
                        Pin = 2468,
                        FechaVencimiento = new DateTime(2029, 5, 2)
                    },

                    new Model.Tarjeta
                    {
                        Numero = 2468246824682468,
                        Bloqueada = true,
                        Monto = 456284,
                        Pin = 1357,
                        FechaVencimiento = new DateTime(2024, 12, 8)
                    },

                    new Model.Tarjeta
                    {
                        Numero = 1357135713571357,
                        Bloqueada = false,
                        Monto = 125999,
                        Pin = 9753,
                        FechaVencimiento = new DateTime(2021, 12, 2)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
