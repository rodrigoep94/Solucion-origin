using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solucion.Interfaces;
using Solucion.Model;
using Solucion.Model.DTO;

namespace Solucion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetasController : ControllerBase
    {
        private ITarjetaRepository repository;

        public TarjetasController(ITarjetaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<Tarjeta> Get()
        {
            return this.repository.GetAll();
        }

        [HttpGet]
        [Route("validarExistenciaTarjeta/{numeroTarjeta}")]
        public IActionResult ValidarExistenciaTarjeta(long numeroTarjeta)
        {
            try
            {
                var existe = this.repository.VerificarExistenciaDeTarjeta(numeroTarjeta);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("obtenerBalance/{numeroTarjeta}")]
        public IActionResult ObtenerBalance(long numeroTarjeta)
        {
            try
            {
                var balanceModel = this.repository.ObtenerBalance(numeroTarjeta);
                return this.Ok(balanceModel);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("validarPin")]
        public IActionResult ValidarPin(ValidacionPinDto model)
        {
            try
            {
                var pinValido = this.repository.ValidarPin(model);

                if (pinValido)
                {
                    return this.Ok();
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch(Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("bloquearTarjeta/{numeroTarjeta}")]
        public IActionResult BloquearTarjeta(long numeroTarjeta)
        {
            this.repository.BloquearTarjeta(numeroTarjeta);
            return this.Ok();
        }
    }
}
