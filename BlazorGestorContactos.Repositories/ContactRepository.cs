using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// El repositoio es el acceso a datos de la app 
// hay que añadirlo al contenedor de dependencias en este caso en la clase Startup.cd del lado del servido que es quien comunica con el repositorio
namespace BlazorGestorContactos.Repositories
{
    public class ContactRepository : IContactRepository
    {
    }
}
