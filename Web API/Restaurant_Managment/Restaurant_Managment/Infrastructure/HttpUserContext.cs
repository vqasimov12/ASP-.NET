﻿using Application.Security;
using System.Security.Claims;

namespace RestaurantManagment.Infrastructure;

public class HttpUserContext : IUserContext
{
    private readonly int _id;

    public int UserId => _id;

    public HttpUserContext(IHttpContextAccessor httpContextAccessor)
    {
        var id = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        _id = Int32.Parse(id);
    }

    public int MustGetUserId()
    {
        if (_id <= 0)
            throw new InvalidOperationException("User has to login");
        return _id;
    }
}
