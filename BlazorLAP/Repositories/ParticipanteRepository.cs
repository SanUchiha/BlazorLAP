using BlazorLAP.Configurations;
using BlazorLAP.Dtos.Response;
using BlazorLAP.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BlazorLAP.Repositories;

public class ParticipanteRepository(ApplicationDbContext context) : IParticipanteRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Participante>> ObtenerTodosLosParticipantesAsync() => 
        await _context.Participantes
            .Include(c => c.IdCampusNavigation)
            .ToListAsync() ?? [];

    public async Task<List<Participante>> ObtenerParticipantesPorCampusAsync(int idCampus) => 
        await _context.Participantes.Where(p => p.IdCampus == idCampus).ToListAsync();

    public async Task<Participante?> ObtenerParticipantePorDNIAsync(string dni) =>
        await _context.Participantes.FirstOrDefaultAsync(p => p.Dniparticipante == dni);

    async Task<CreateParticipanteDTO> IParticipanteRepository.AgregarParticipanteAsync(Participante participante)
    {
        try
        {
            await _context.Participantes.AddAsync(participante);
            await _context.SaveChangesAsync();

            CreateParticipanteDTO result = new()
            {
                IsSuccess = true,
                ErrorMessage = "",
                ErrorType = "",
                Message = $"Partipante con DNI: {participante.Dniparticipante} creado con exito para el campus: {participante.IdCampus}",
                Participante = participante
            };

            return result;
        }
        catch (Exception ex) 
        {
            CreateParticipanteDTO result = new()
            {
                IsSuccess = true,
                ErrorMessage = ex.Message,
                ErrorType = ex.GetType().ToString(),
                Message = $"No se ha podido crear el partipante con DNI: {participante.Dniparticipante} para el campus {participante.IdCampus}",
                Participante = participante
            };

            return result;
        }
    }

    async Task<UpdateParticipanteDTO> IParticipanteRepository.ModificarParticipanteAsync(Participante participante)
    {
        /*_context.Participantes.Update(participante);
        await _context.SaveChangesAsync();*/
        throw new NotImplementedException();
    }

    async Task<DeleteParticipanteDTO> IParticipanteRepository.EliminarParticipanteAsync(int id)
    {
        /*var participante = await _context.Participantes.FindAsync(id);
        if (participante != null)
        {
            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();
        }*/
        throw new NotImplementedException();

    }

    public async Task<Participante?> ObtenerParticipantePorIdAsync(int id) =>
        await _context.Participantes
            .Include(p => p.IdCampusNavigation)
            .FirstOrDefaultAsync(p => p.IdParticipante == id);
}
