namespace Web_intro.DTOs.UserDTOs;

public record struct UpdateUserDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public short Age { get; set; }
}