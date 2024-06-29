namespace CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}