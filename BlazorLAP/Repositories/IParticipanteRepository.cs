using BlazorLAP.Dtos.Response;
using BlazorLAP.Models;

namespace BlazorLAP.Repositories;

public interface IParticipanteRepository
{
    Task<List<Participante>> ObtenerTodosLosParticipantesAsync();
    Task<List<Participante>> ObtenerParticipantesPorCampusAsync(int idCampus);
    Task<Participante?> ObtenerParticipantePorDNIAsync(string dni);
    Task<Participante?> ObtenerParticipantePorIdAsync(int id);
    Task<CreateParticipanteDTO> AgregarParticipanteAsync(Participante participante);
    Task<UpdateParticipanteDTO> ModificarParticipanteAsync(Participante participante);
    Task<DeleteParticipanteDTO> EliminarParticipanteAsync(int id);
}
