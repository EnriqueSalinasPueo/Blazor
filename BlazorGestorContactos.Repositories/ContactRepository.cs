using BlazorGestorContactos.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// El repositoio es el acceso a datos de la app 
// hay que añadirlo al contenedor de dependencias en este caso en la clase Startup.cd del lado del servido que es quien comunica con el repositorio
namespace BlazorGestorContactos.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _dbConnetion;

        public ContactRepository(IDbConnection dbConnetion)
        {
            _dbConnetion = dbConnetion;
        }

        public Task DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAll(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatetContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
