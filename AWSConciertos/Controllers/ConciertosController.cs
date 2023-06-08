using AWSConciertos.Models;
using AWSConciertos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSConciertos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConciertosController : ControllerBase
    {
        private RepositoryConciertos repo;
        public ConciertosController(RepositoryConciertos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Eventos()
        {
            return Ok(await this.repo.Eventos());
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CategoriasEventos()
        {
            return Ok(await this.repo.CategoriasEventos());
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> EventosCategoria(int id)
        {
            return Ok(await this.repo.EventosCategoria(id));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> InsertEvento(Evento evento)
        {
            await this.repo.InsertEvento(evento.Nombre, evento.Artista, evento.IdCategoria, evento.Imagen);
            return Ok();
        }
    }
}
