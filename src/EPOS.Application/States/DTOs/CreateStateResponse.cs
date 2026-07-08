namespace EPOS.Application.States.DTOs;

public class CreateStateResponse
{
    public bool Success { get; set; }

    public Guid StateId { get; set; }

    public string Message { get; set; } = string.Empty;
}