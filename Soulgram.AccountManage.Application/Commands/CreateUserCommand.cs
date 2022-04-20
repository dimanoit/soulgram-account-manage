using MediatR;
using Soulgram.AccountManage.Application.Model.Requests;

namespace Soulgram.AccountManage.Application.Commands;

public sealed class CreateUserCommand : IRequest
{
    public CreateUserRequest RequestModel { get; init; }
}