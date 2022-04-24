using MediatR;

namespace Soulgram.AccountManage.Application.Commands;

public class SendMateRequestCommand: IRequest
{
    public string RecipientId { get; set; }
    public string SenderId { get; set; }
}