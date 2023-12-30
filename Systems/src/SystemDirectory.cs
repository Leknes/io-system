using Senkel.IO.Paths;
using System.IO;

namespace Senkel.IO.Systems;

public class SystemDirectory : ISystemDirectory
{
    private ISystemPath _path;

    private string Path => _path.Path;

    public SystemDirectory(ISystemPath path)
    {
        _path = path;
    }

    public DirectoryInfo ToInfo()
    {
        return new DirectoryInfo(Path);
    }

    public void Create()
    {
        Directory.CreateDirectory(Path);
    }

    public void Delete(bool recursive)
    {
        Directory.Delete(Path, recursive);
    }

    public void Delete()
    {
        Directory.Delete(Path);
    }

    public bool Exists()
    {
        return Directory.Exists(Path);
    }
}