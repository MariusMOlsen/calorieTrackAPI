using ErrorOr;
using MediatR;
using System.Reflection;
using CalorieTrack.Application.Common.Authorization;
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model;

namespace CalorieTrack.Application.Common.Behaviours
{
    public class AuthorizationBehavior<TRequest, TResponse>(ICurrentUserProvider _currentUserProvider)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var authorizationAttributes = request.GetType()
                .GetCustomAttributes<AuthorizeAttribute>()
                .ToList();

            if (authorizationAttributes.Count == 0)
            {
                return await next();
            }
            else
            {
            var currentUser = _currentUserProvider.GetCurrentUser();




            List<ProfileType> requiredRoles = authorizationAttributes
                .Select(r => r.Roles).ToList();
            
            if(!requiredRoles.Any((requestedRole) => requestedRole == currentUser.Role))
            {
                return (dynamic)Error.Unauthorized(description: "User is forbidden from taking this action");
            }
      
            

            return await next();
                
            }

        }
    }
}