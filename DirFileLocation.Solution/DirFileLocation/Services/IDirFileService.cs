using DirFileLocation.Models;

namespace DirFileLocation.Services
{
    public interface IDirFileService
    {
         List<DirFileInfo> GetDirFile(string path);

    }
}
