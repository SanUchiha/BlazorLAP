using BlazorLAP.Models;

namespace BlazorLAP.Dtos.Response;

public class UpdateParticipanteDTO: ResponseDTO
{
    public Participante? Participante { get; set; }
    public Campus? Campus { get; set; }
}
