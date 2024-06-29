using CalorieTrack.Domain.Model;

namespace CalorieTrack.Application.Common.Models;

public record CurrentUser(
    Guid Id,
    ProfileType Role);
    
    public record RegisterUser(
    string Email,string? FirstName,string? LastName, string Id);