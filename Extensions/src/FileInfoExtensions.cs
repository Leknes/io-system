using System.IO;

namespace Senkel.IO;

public static class FileInfoExtensions
{
    /// <summary>
    /// Creates all directories and sub-directories in the path of the parent directory unless they already exist.
    /// </summary>
    /// <param name="fileInfo">The file of which the parent directory will be created.</param>
    public static void CreateParentDirectory(this FileInfo fileInfo)
    {
        string? directoryPath = fileInfo.DirectoryName;

        if (string.IsNullOrEmpty(directoryPath))
            return;

        DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

        if (!directoryInfo.Exists)
            directoryInfo.Create();
    }
}