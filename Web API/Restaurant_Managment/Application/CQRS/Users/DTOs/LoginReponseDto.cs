
namespace Application.CQRS.Users.DTOs;

public class LoginReponseDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}