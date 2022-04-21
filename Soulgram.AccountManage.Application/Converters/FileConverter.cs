using Microsoft.AspNetCore.Http;
using FileInfo = Soulgram.File.Manager.Models.FileInfo;

namespace Soulgram.AccountManage.Application.Converters;

public static class FileConverter
{
    // TODO move this converter to nuget package
    public static FileInfo ToFileInfo(this IFormFile file)
    {
        var fileInfo = new FileInfo
        {
            Content = file.OpenReadStream(),
            ContentType = file.ContentType,
            Name = file.FileName
        };

        return fileInfo;
    }
}