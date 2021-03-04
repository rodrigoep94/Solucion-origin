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
    public class ExtraccionController : ControllerBase
    {
        private IExtraccionRepository repository;

        public ExtraccionController(IExtraccionRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("extraer")]
        public IActionResult Extraer(ExtraccionDto model)
        {
            try
            {
                var extraccion = this.repository.Extraer(model);

                return this.Ok(extraccion);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRetiro(int id)
        {
            try
            {
                var extraccion = this.repository.GetRetiroFullEntity(id);

                return this.Ok(extraccion);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
