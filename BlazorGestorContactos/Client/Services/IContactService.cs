using BlazorGestorContactos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// En esta interface pondremos todos los metodos que implemetara nuestara clase ContactService
namespace BlazorGestorContactos.Client.Services
{
    public interface IContactService
    {
        Task SaveContact(Contact contact);
        Task DeleteContact(int id);
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetContact(int id);
    }
}
