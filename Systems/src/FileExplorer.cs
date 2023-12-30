using Senkel.IO.Paths;
using System.IO;

namespace Senkel.IO.Systems;

public class FileExplorer : IFileExplorer
{
    private FileExplorer() { }

    public static FileExplorer Instance { get; } = new FileExplorer();

    public void Copy(string sourcePath, string destinationPath, bool overwrite = false)
    {
        File.Copy(sourcePath, destinationPath, overwrite);
    }

    public SystemFile Locate(ISystemPath path)
    {
        return new SystemFile(path);
    }

    public void Move(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    ISystemEntry ISystemExplorer.Locate(ISystemPath path) => Locate(path);
    ISystemFile IFileExplorer.Locate(ISystemPath path) => Locate(path);
}