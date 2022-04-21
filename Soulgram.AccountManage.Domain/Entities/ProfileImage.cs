namespace Soulgram.AccountManage.Domain.Entities;

public class ProfileImage
{
    public string Id { get; set; }
    public string ImgUrl { get; set; }

    public DateTime CreationDate { get; set; }

    public string UserId { get; set; }
    public UserInfo UserInfo { get; set; }
}