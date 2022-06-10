using BlazorGestorContactos.Repositories;
using BlazorGestorContactos.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// Creamos un controlador que se encargara de llamar al repositorio
namespace BlazorGestorContactos.Server.Controllers
{
    // URL "api/Contact"
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(contact.Nombre))
            {
                ModelState.AddModelError("Nombre", "Nombre no puede estar vacio");
            }
            if (string.IsNullOrEmpty(contact.Apellido))
            {
                ModelState.AddModelError("Nombre", "Nombre no puede estar vacio");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactRepository.InsertContact(contact);

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(contact.Nombre))
            {
                ModelState.AddModelError("Nombre", "Nombre no puede estar vacio");
            }
            if (string.IsNullOrEmpty(contact.Apellido))
            {
                ModelState.AddModelError("Nombre", "Nombre no puede estar vacio");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactRepository.UpdatetContact(contact);

            return NoContent();

        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
           IEnumerable<Contact> result = await _contactRepository.GetAll();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<Contact> Get(int id )
        {
            return await _contactRepository.GetContact(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _contactRepository.DeleteContact(id);

        }
    }
}
