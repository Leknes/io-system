using Senkel.IO.Paths;
using System.IO;

namespace Senkel.IO.Systems;

public class DirectoryExplorer : IDirectoryExplorer
{
    public SystemDirectory Locate(ISystemPath path)
    {
        return new SystemDirectory(path);
    }

    public void Move(string sourcePath, string destinationPath)
    {
        Directory.Move(sourcePath, destinationPath);
    }

    ISystemEntry ISystemExplorer.Locate(ISystemPath path) => Locate(path);
    ISystemDirectory IDirectoryExplorer.Locate(ISystemPath path) => Locate(path);
}