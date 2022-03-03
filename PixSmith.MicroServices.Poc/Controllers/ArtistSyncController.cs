using Microsoft.AspNetCore.Mvc;
using PixSmith.MicroServices.Domain;
using PixSmith.MicroServices.Services.Interfaces;

namespace PixSmith.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistSyncController : ControllerBase
    {
        private readonly IArtistService service;

        public ArtistSyncController(IArtistService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("{guid}")]
        public Artist Get([FromRoute] string guid)
        {
            return this.service.Get(Guid.Parse(guid)).Result;
        }

        [HttpPost]
        [Route("save")]
        public Artist Save([FromBody] Artist artist)
        {
            return this.service.Save(artist).Result;
        }

        [HttpDelete]
        [Route("delete/{guid}")]
        public IActionResult Delete([FromRoute] Guid guid)
        {
            this.service.Delete(guid).Wait();

            return Ok();
        }
    }
}
