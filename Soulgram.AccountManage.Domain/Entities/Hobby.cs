namespace Soulgram.AccountManage.Domain.Entities;

public class Hobby
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Desription { get; set; }
    public bool IsActive { get; set; }
    public bool IsGroupOnly { get; set; }
    public int CountOfUsage { get; set; }

    public ICollection<HobbyImage> HobbyImages { get; set; }
    public ICollection<UserHobby> UserHobbies { get; set; }
}