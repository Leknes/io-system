using Senkel.IO.Paths;
using System.IO;

namespace Senkel.IO.Systems;

public class SystemFile : ISystemFile
{
    private readonly ISystemPath _path;

    private string Path => _path.Path;

    public SystemFile(ISystemPath path)
    {
        _path = path;
    }

    public FileInfo ToInfo()
    {
        return new FileInfo(Path);
    }

    public FileStream Create()
    {
        FileInfo info = new FileInfo(Path);

        info.CreateParentDirectory();

        return info.Create();
    }

    public void Delete()
    {
        File.Delete(Path);
    }

    public bool Exists()
    {
        return File.Exists(Path);
    }

    public FileStream Open(FileMode mode = FileMode.OpenOrCreate, FileAccess access = FileAccess.ReadWrite)
    {
        FileInfo info = ToInfo();

        if ((access & FileAccess.Write) == FileAccess.Write && (mode == FileMode.OpenOrCreate || mode == FileMode.CreateNew || mode == FileMode.Create))
            info.CreateParentDirectory();

        return info.Open(mode, access);
    }

    Stream ISystemFile.Create() => Create();
    Stream ISystemFile.Open(FileMode mode, FileAccess access) => Open(mode, access);
}
