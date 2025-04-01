using BlazorLAP.Models;

namespace BlazorLAP.Dtos.Response;

public class CreateParticipanteDTO: ResponseDTO
{
    public Participante? Participante { get; set; }
}
