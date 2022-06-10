using BlazorGestorContactos.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

// Desde el servicio haremos la llamada al Controlador
// hay que añadirlo al contenedor de dependencias en este caso en la clase Program.cd
namespace BlazorGestorContactos.Client.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task DeleteContact(int id)
        {
            await _httpClient.DeleteAsync($"api/contact/{id}");
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            // Este metodo deserializa un Json para poder mandarlo al controlador como objeto o en este caso lista de objetos
            IEnumerable<Contact> result = await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>($"api/contact");

            return result;
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _httpClient.GetFromJsonAsync<Contact>($"api/contact/{id}");
        }

        public async Task SaveContact(Contact contact)
        {
            if (contact.Id == 0)
            {
                // insert
                await _httpClient.PostAsJsonAsync<Contact>($"api/contact", contact);
            }
            else
            {
                // update
                await _httpClient.PutAsJsonAsync<Contact>($"api/contact/{contact.Id}", contact);
            }
        }
    }
}
