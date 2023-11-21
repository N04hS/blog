using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Blog.API.Entities;

public class User : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}