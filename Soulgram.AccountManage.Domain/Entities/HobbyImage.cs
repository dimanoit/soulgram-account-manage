namespace Soulgram.AccountManage.Domain.Entities;

public class HobbyImage
{
    public string Id { get; set; }
    public string ImgUrl { get; set; }

    public string HobbyId { get; set; }
    public Hobby Hobby { get; set; }
}