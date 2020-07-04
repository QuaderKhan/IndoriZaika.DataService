using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indorizaika.Dataservice.Services;
using IndoriZaika.DataService.Models;
using indorizaikaDataService.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndoriZaika.DataService.Controllers
{
    [Route("izdbapi/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly IProcedureService _procedureService;

        public ProcedureController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        // GET: api/<ProcedureController>
        [HttpGet]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<IEnumerable<ProcedureModel>> Get()
        {
            return await _procedureService.GetAllProcedures();
        }

        // GET api/<ProcedureController>/5
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<ProcedureModel>> Get(int id)
        {
            var procedureForRecipe = await _procedureService.GetProcedureForRecipe(id);

            if (procedureForRecipe == null)
            {
                return NotFound();
            }

            return procedureForRecipe;
        }

        // POST api/<ProcedureController>
        [HttpPost]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<ProcedureModel>> Post(ProcedureModel procedureModel)
        {
            await _procedureService.Save(procedureModel);

            return CreatedAtAction("Get", new { id = procedureModel.Id }, procedureModel);
        }

        // PUT api/<ProcedureController>/5
        [HttpPut("{id}")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] ProcedureModel procedureModel)
        {
            if (id != procedureModel.Id)
            {
                return BadRequest();
            }

            return await _procedureService.Update(procedureModel);
        }

        // DELETE api/<ProcedureController>/5
        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _procedureService.Delete(id);
        }
    }
}
