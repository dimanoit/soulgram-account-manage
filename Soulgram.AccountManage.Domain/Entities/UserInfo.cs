namespace Soulgram.AccountManage.Domain.Entities;

public class UserInfo
{
    public string UserId { get; set; }
    public DateTime Birthdate { get; set; }
    public string Email { get; set; }
    public string Nickname { get; set; }

    public string Fullname { get; set; }

    public ICollection<ProfileImage> ProfileImages { get; set; }
    public ICollection<UserHobby> UserHobbies { get; set; }
}