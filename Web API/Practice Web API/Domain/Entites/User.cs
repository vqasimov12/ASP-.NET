﻿
using Domain.BaseEntities;

namespace Domain.Entites;

public class User:BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PasswordHash { get; set; }
}