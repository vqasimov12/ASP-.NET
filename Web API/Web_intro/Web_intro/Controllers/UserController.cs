using Microsoft.AspNetCore.Mvc;
using Web_intro.DTOs.UserDTOs;
using Web_intro.Entities;

namespace Web_intro.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    List<User> _userList =
    [
        new User {Id="6c2bd9b8-50b6-45db-a436-256aaaf8a028" , Name="Iman",Surname="Eyvazov",Email="iman@gmail.com",Age=18},
        new User {Id="6c2bd9b8-50b6-45db-a436-256aaaf8a0282" , Name="Mirtalib",Surname="Emirli",Email="mirtalib@gmail.com",Age=20},
        new User {Id="6c2bd9b8-50b6-45db-a436-256aaaf8a0283", Name="Taleh",Surname="Haciyev",Email="Taleh@gmail.com",Age=25}
    ];

    [HttpGet]
    [Route("UserList")]
    public List<User> GetUserList() => _userList;

    [HttpGet]
    [Route($"GetById")]
    public User GetUserById(string id) => _userList.FirstOrDefault(z => z.Id == id)!;


    [HttpPost]
    public List<User> Add([FromBody] User user)
    {
        _userList.Add(user);
        return _userList;
    }


    [HttpPut("{id}")]
    public List<User> Update([FromBody] UpdateUserDTO model,string id)
    {
        var _user = _userList.FirstOrDefault(u => u.Id == id);
        _user.Name= model.Name;
        _user.Surname= model.Surname;
        _user.Age = model.Age;
        return _userList;
    }

    [HttpDelete("{id}")]
    public List<User>Delete(string id)
    {
        _userList.Remove(_userList.FirstOrDefault(z => z.Id == id)!);
        return _userList;
    }


}