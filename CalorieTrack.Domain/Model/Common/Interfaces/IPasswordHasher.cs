using ErrorOr;
namespace CalorieTrack.Domain.Model.Common.Interfaces;

public interface IPasswordHasher
{
    public ErrorOr<string> HashPassword(string password);
    bool IsCorrectPassword(string password, string hash);
}