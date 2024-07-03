using System.Diagnostics;
using System.Security.Claims;
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.Common.Models;
using CalorieTrack.Domain.Model;
using ErrorOr;
using Throw;

namespace CalorieTrack.Api.Services;

public class CurrentUserProvider(IHttpContextAccessor _httpContextAccessor) : ICurrentUserProvider
{
    
   // IHttpContextAccessor  _httpContextAccessor = httpContextAccessor;
    public CurrentUser GetCurrentUser()
    {
        _httpContextAccessor.HttpContext.ThrowIfNull();

        var test2 = GetClaimValues("id");
        Guid? id = test2
            .Select(Guid.Parse)
            .First();
        if (id == Guid.Empty || id == null)
        {
            throw new Exception("Id not found");
        }

      //  var permissions = GetClaimValues("permissions");
        string profileTypeInt =  GetClaimValues("role")
            
            .First();
        Debug.WriteLine("profileTypeInt: " + profileTypeInt);
        if (profileTypeInt == null)
        {
            throw new  Exception("Role not found");
        }

        return new CurrentUser(Id: (Guid)id, Role: (ProfileType)(int.Parse(profileTypeInt)));
    }

    private IReadOnlyList<string> GetClaimValues(string claimType)
    {
        if(_httpContextAccessor.HttpContext!.User == null)
        {
            throw new Exception("User not found");
        }
        if(_httpContextAccessor.HttpContext!.User.Claims == null)
        {
            throw new Exception("Claims not found");
        }
      var test  = _httpContextAccessor.HttpContext!.User.Claims
            .Where(claim => claim.Type == claimType)
            .Select(claim => claim.Value)
            .ToList();

      return test;
    }
}
