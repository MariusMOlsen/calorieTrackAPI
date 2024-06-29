using ErrorOr;
using CalorieTrack.Application.Authentication.Common;
using MediatR;

namespace CalorieTrack.Application.Authentication.Commands.Register;

public record RegisterCommand(
  string credential) : IRequest<ErrorOr<AuthenticationResult>>;