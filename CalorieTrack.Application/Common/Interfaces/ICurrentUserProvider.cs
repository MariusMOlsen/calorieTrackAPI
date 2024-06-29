using CalorieTrack.Application.Common.Models;

namespace CalorieTrack.Application.Common.Interfaces;

public interface ICurrentUserProvider
{
    CurrentUser GetCurrentUser();
}