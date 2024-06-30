using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using CalorieTrack.Domain.Model.Common;
using CalorieTrack.Domain.Model.Common.Interfaces;
using ErrorOr;

namespace CalorieTrack.Domain.Model;

public class User
    : Entity
{
    public string GoogleUserId { get; set; } 
    public string? FirstName { get; }
    public string? LastName { get; } 
    public string Email { get; } = null!;
    public ProfileType ProfileType { get; private set; }
    
    private readonly string? _passwordHash = null;
    
    public User(
        string? firstName,
        string? lastName,
        string email,
        string id
        )
        : base(Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        ProfileType = ProfileType.FreeMember;
        GoogleUserId = id;
    }
    
    public bool IsCorrectPasswordHash(string password, IPasswordHasher passwordHasher)
    {
        return passwordHasher.IsCorrectPassword(password, _passwordHash);
    }
    
 

    public User() { }
    
}