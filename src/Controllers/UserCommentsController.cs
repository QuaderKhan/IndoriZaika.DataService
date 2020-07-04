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
    public class UserCommentsController : ControllerBase
    {
        private readonly IUserCommentsService _userCommentsService;

        public UserCommentsController(IUserCommentsService userCommentsService)
        {
            _userCommentsService = userCommentsService;
        }

        // GET: api/<UserCommentsController>
        [HttpGet]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<IEnumerable<UserCommentsModel>> Get()
        {
            return await _userCommentsService.GetAllUserComments();
        }

        // GET api/<UserCommentsController>/5
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<UserCommentsModel>> Get(int id)
        {
            var userCommentsForRecipe = await _userCommentsService.GetUserCommentsForRecipe(id);

            if (userCommentsForRecipe == null)
            {
                return NotFound();
            }

            return userCommentsForRecipe;
        }

        // POST api/<UserCommentsController>
        [HttpPost]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<UserCommentsModel>> Post(UserCommentsModel userCommentsModel)
        {
            await _userCommentsService.Save(userCommentsModel);

            return CreatedAtAction("Get", new { id = userCommentsModel.Id }, userCommentsModel);
        }

        // PUT api/<UserCommentsController>/5
        [HttpPut("{id}")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] UserCommentsModel userCommentsModel)
        {
            if (id != userCommentsModel.Id)
            {
                return BadRequest();
            }

            return await _userCommentsService.Update(userCommentsModel);
        }

        // DELETE api/<UserCommentsController>/5
        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _userCommentsService.Delete(id);
        }
    }
}
