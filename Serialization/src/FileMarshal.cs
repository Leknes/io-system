using Senkel.IO.Paths;
using Senkel.IO.Systems;
using Senkel.Serialization;
using System.IO;

namespace Senkel.IO.Serialization;

public class FileMarshal : IMarshal<string>
{
    private readonly IFileExplorer _explorer;

    private readonly IMarshal<Stream> _marshal;

    private readonly FileMode _mode;

    public FileMarshal(IFileExplorer explorer, IMarshal<Stream> marshal, FileMode mode = FileMode.OpenOrCreate)
    {
        _explorer = explorer;
        _marshal = marshal;
        _mode = mode;
    }

    public void Marshal(string path, object? value)
    {
        using Stream stream = _explorer.Locate(new FilePath(path)).Open(_mode, FileAccess.Write);

        _marshal.Marshal(stream, value);
    }
}
