using MediatR;
using Soulgram.AccountManage.Application.Model.Requests;

namespace Soulgram.AccountManage.Application.Commands;

public class CreateHobbyCommand : IRequest
{ 
    public CreateHobbyRequest RequestModel { get; init; }
}