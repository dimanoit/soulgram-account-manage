namespace Soulgram.AccountManage.Domain.Entities;

public class Genre
{
    public string Name { get; set; }
    public int CountOfUsage { get; set; }
    
    public ICollection<UserGenre> UserGenres { get; set; }
}