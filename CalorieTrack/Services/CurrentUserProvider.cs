using System.Security.Claims;
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.Common.Models;
using CalorieTrack.Domain.Model;
using Throw;

namespace CalorieTrack.Api.Services;

public class CurrentUserProvider(IHttpContextAccessor _httpContextAccessor) : ICurrentUserProvider
{
    public CurrentUser GetCurrentUser()
    {
        _httpContextAccessor.HttpContext.ThrowIfNull();

        var id = GetClaimValues("id")
            .Select(Guid.Parse)
            .First();

        var permissions = GetClaimValues("permissions");
        int profileTypeInt =  GetClaimValues("role")
            .Select(int.Parse)
            .First();

        return new CurrentUser(Id: id, Role: (ProfileType)profileTypeInt);
    }

    private IReadOnlyList<string> GetClaimValues(string claimType)
    {
        return _httpContextAccessor.HttpContext!.User.Claims
            .Where(claim => claim.Type == claimType)
            .Select(claim => claim.Value)
            .ToList();
    }
}
