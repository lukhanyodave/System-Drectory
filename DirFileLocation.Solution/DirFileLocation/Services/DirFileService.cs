using DirFileLocation.Models;

namespace DirFileLocation.Services
{
    public class DirFileService : IDirFileService
    {
        public List<DirFileInfo> GetDirFile(string path)
        {
            // Create a DirectoryInfo object for the specified directory path
            DirectoryInfo directory = new DirectoryInfo(path);
            // Get all files and directories in the specified directory
            FileSystemInfo[] info =  directory.GetFileSystemInfos("*", SearchOption.AllDirectories);
            // Create an array to hold the results
            var results =  new DirFileInfo[info.Length];

            // Loop through each file or directory and add its information to the results array
            for (int i = 0; i < info.Length; i++)
            {
                FileSystemInfo fileOrDirectory = info[i];
                //build the results
                results[i] =  new DirFileInfo
                {
                    id = i + 1,
                    Path = fileOrDirectory.FullName,
                    Size = (fileOrDirectory is FileInfo fileInfo) ? fileInfo.Length : 0,
                    Attributes = fileOrDirectory.Attributes.ToString()
                };
            }

            return  results.ToList();
        }



        //public DirFileInfo[] GetDirFileinfo(FileSystemInfo[] info)
        //{
        //    // Create an array to hold the results
        //    var results = new DirFileInfo[info.Length];

        //    // Loop through each file or directory and add its information to the results array
        //    for (int i = 0; i < info.Length; i++)
        //    {
        //        FileSystemInfo fileOrDirectory = info[i];

        //        results[i] = new DirFileInfo
        //        {
        //            Path = fileOrDirectory.FullName,
        //            Size = (fileOrDirectory is FileInfo fileInfo) ? fileInfo.Length : 0,
        //            Attributes = fileOrDirectory.Attributes.ToString()
        //        };
        //    }

        //    return results;
        //}
    }
}
