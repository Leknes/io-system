using Senkel.IO.Paths;
using Senkel.IO.Systems;
using System.IO;

namespace Senkel.IO.Conversions;

public class FileStreamConverter : IConverter<string, Stream>
{
    private readonly IFileExplorer _explorer;

    private readonly FileMode _mode;
    private readonly FileAccess _access;

    public FileStreamConverter(IFileExplorer explorer, FileMode mode = FileMode.OpenOrCreate, FileAccess access = FileAccess.ReadWrite)
    {
        _explorer = explorer;

        _mode = mode;
        _access = access;
    }

    public Stream Convert(string path)
    {
        return _explorer.Locate(new FilePath(path)).Open(_mode, _access);
    }
}