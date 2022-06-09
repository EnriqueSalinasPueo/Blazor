using BlazorGestorContactos.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// El repositoio es el acceso a datos de la app 
// hay que añadirlo al contenedor de dependencias en este caso en la clase Startup.cd del lado del servido que es quien comunica con el repositorio
// Haremos todas nuestras conaultas en el repositorio.
namespace BlazorGestorContactos.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _dbConnetion;

        public ContactRepository(IDbConnection dbConnetion)
        {
            _dbConnetion = dbConnetion;
        }

        public async Task DeleteContact(int id)
        {
            var sql = @"DELETE FROM Contact WHERE Id = @Id";

            var result = await _dbConnetion.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var sql = @"SELELCT * FROM Contact";

            return await _dbConnetion.QueryAsync<Contact>(sql, new { });
        }

        public async Task<Contact> GetContact(int id)
        {
            var sql = @"SELELCT * FROM Contact WHERE Id = @Id";

            return await _dbConnetion.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = id });
        }

        public async Task<bool> InsertContact(Contact contact)
        {
            try
            {
                var sql = @"INSERT INTO Contact(Nombre, Apellidos, Telefono, Direccion)
                            VALUES(@Nombre, @Apellidos, @Telefono, @Direccion) ";
                var result = await _dbConnetion.ExecuteAsync(sql, new
                {
                    contact.Nombre,
                    contact.Apellido,
                    contact.Telefono,
                    contact.Direcion
                });

                return result > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> UpdatetContact(Contact contact)
        {
            try
            {
                var sql = @"UPDATE Contact
                            SET Nombre = @Nombre, 
                                Apellidos = @Apellidos, 
                                Telefono = @Telefono, 
                                Direccion = @Direccion)
                                WHERE Id = @Id ";
                var result = await _dbConnetion.ExecuteAsync(sql, new
                {
                    contact.Nombre,
                    contact.Apellido,
                    contact.Telefono,
                    contact.Direcion,
                    contact.Id
                });

                return result > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

