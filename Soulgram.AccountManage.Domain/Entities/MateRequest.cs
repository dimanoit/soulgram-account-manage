namespace Soulgram.AccountManage.Domain.Entities;

public class MateRequest
{
    public string SenderId { get; set; }
    public string RecipientId { get; set; }
    public MateRequestStatus Status { get; set; }
    public DateTime CreationDate { get; set; }
}