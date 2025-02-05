using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebUI.Models;

public class RegisterViewModel
{
    public string Username {  get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }   

    


}