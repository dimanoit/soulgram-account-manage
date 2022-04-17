using MediatR;
using Soulgram.AccountManage.Appliaction.Model.Requests;

namespace Soulgram.AccountManage.Appliaction.Commands;

public sealed class CreateUserCommand : IRequest
{
    public CreateUserCommand(CreateUserRequest requestModel)
    {
        RequestModel = requestModel;
    }

    public CreateUserRequest RequestModel { get; }
}