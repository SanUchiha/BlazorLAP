using BlazorLAP.Models;

namespace BlazorLAP.Repositories;

public interface ICampusRepository
{
    Task<List<Campus>> ObtenerTodosLosCampusAsync();
    Task<Campus?> ObtenerCampusAsync(int id);
    Task AgregarCampusAsync(Campus campus);
    Task ModificarCampusAsync(Campus campus);
    Task EliminarCampusAsync(int id);
}
