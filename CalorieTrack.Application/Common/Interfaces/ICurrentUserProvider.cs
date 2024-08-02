using CalorieTrack.Application.Common.Models;
using ErrorOr;
namespace CalorieTrack.Application.Common.Interfaces;

public interface ICurrentUserProvider
{
    ErrorOr<CurrentUser> GetCurrentUser();
}