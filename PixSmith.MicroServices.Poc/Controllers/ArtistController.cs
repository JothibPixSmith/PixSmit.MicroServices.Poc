using Microsoft.AspNetCore.Mvc;
using PixSmith.MicroServices.Domain;
using PixSmith.MicroServices.Services.Interfaces;

namespace PixSmith.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService service;

        public ArtistController(IArtistService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("{guid}")]
        public async Task<Artist> Get([FromRoute] string guid)
        {
            return await this.service.Get(Guid.Parse(guid));
        }

        [HttpPost]
        [Route("save")]
        public async Task<Artist> Save([FromBody] Artist artist)
        {
            return await this.service.Save(artist);
        }

        [HttpDelete]
        [Route("delete/{guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid guid)
        {
            await this.service.Delete(guid);

            return Ok();
        }

    }
}
