using MVCBiblioteca.Models;

namespace MVCBiblioteca.Services.Interfaces
{
    public interface IBibliotecasAPIService
    {
        Task<IEnumerable<Biblioteca>> Find();
    }
}
