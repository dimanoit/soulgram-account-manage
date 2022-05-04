namespace Soulgram.AccountManage.Domain.Entities;

public class UserGenre
{
    public string GenreName { get; set; }
    public Genre Genre { get; set; }
    
    public string UserId { get; set; }
    public UserInfo User { get; set; }
    
    public DateTime CreationDate { get; set; }
}