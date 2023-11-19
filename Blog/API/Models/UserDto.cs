﻿using Blog.API.Entities;

namespace Blog.API.Models;

public class UserDto
{
    public UserDto() { }
    public UserDto(User user)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
    }

    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
