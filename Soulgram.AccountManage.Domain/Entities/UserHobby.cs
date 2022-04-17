namespace Soulgram.AccountManage.Domain.Entities;

public class UserHobby
{
    public DateTime CreationDate { get; set; }

    public string UserId { get; set; }
    public UserInfo UserInfo { get; set; }

    public string HobbieId { get; set; }
    public Hobby Hobby { get; set; }
}