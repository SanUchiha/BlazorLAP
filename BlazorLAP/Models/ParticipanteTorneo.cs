namespace BlazorLAP.Models;

public class ParticipanteTorneo
{
    public int Id { get; set; }
    public int IdParticipante { get; set; }
    public int IdTorneo { get; set; }
    public DateOnly RegistrationDate { get; set; } = new DateOnly();
}
