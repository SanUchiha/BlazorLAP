namespace BlazorLAP.Dtos.Response;

public class ResponseDTO
{
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    public string? ErrorType { get; set; }
    public required string Message { get; set; }
}
