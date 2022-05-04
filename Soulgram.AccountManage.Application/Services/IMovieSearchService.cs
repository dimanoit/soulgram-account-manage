namespace Soulgram.AccountManage.Application.Services;

public interface IMovieSearchService
{
    Task<ICollection<string>?> GetGenresAsync(CancellationToken cancellationToken);
}