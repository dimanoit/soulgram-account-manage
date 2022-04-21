namespace Soulgram.AccountManage.Application.Model.Requests;

public class CreateHobbyRequest
{
    public string Name { get; set; }
    public string Desription { get; set; }
    public bool IsActive { get; set; }
    public bool IsGroupOnly { get; set; }

    public IEnumerable<string> ImgUrls { get; set; }
}