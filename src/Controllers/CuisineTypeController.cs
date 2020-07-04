using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indorizaika.Dataservice.Services;
using IndoriZaika.DataService.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndoriZaika.DataService.Controllers
{
    [Route("izdbapi/[controller]")]
    [ApiController]
    public class CuisineTypeController : ControllerBase
    {
        private readonly ICuisineTypeService _cuisineTypeService;

        public CuisineTypeController(ICuisineTypeService cuisineTypeService)
        {
            _cuisineTypeService = cuisineTypeService;
        }

        // GET: api/<CuisineTypeController>
        [HttpGet]
        [SwaggerOperation("GetAllCusines")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<IEnumerable<CuisineTypeModel>> Get()
        {
            return await _cuisineTypeService.GetCuisineTypes();
        }

        // GET api/<CuisineTypeController>/5
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<CuisineTypeModel>> Get(int id)
        {
            var cuisineType = await _cuisineTypeService.GetCuisineType(id);

            if (cuisineType == null)
            {
                return NotFound();
            }

            return cuisineType;
        }

        // POST api/<CuisineTypeController>
        [HttpPost]
        public async Task<ActionResult<CuisineTypeModel>> Post(CuisineTypeModel cuisineTypeModel)
        {
            await _cuisineTypeService.Save(cuisineTypeModel);

            return CreatedAtAction("Get", new { id = cuisineTypeModel.Id }, cuisineTypeModel);
        }

        // PUT api/<CuisineTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] CuisineTypeModel cuisineTypeModel)
        {
            if (id != cuisineTypeModel.Id)
            {
                return BadRequest();
            }

            return await _cuisineTypeService.Update(cuisineTypeModel);
        }

        // DELETE api/<CuisineTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _cuisineTypeService.Delete(id);
        }
    }
}
