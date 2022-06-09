using BlazorGestorContactos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorGestorContactos.Repositories
{
    public interface IContactRepository
    {
        Task<bool> InsertContact(Contact contact);
        Task<bool> UpdatetContact(Contact contact);
        Task DeleteContact(int id);
        Task<IEnumerable<Contact>> GetAll(Contact contact);
        Task<Contact> GetContact(int id);

    }
}
