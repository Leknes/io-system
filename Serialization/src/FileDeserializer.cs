using Senkel.IO.Paths;
using Senkel.IO.Systems;
using Senkel.Serialization;
using System;
using System.IO;

namespace Senkel.IO.Serialization;

public class FileDeserializer : IDeserializer<string>
{
    private readonly IFileExplorer _explorer;

    private readonly IDeserializer<Stream> _deserializer;

    private readonly FileMode _mode;

    public FileDeserializer(IFileExplorer explorer, IDeserializer<Stream> deserializer, FileMode mode = FileMode.Open)
    {
        _explorer = explorer;
        _deserializer = deserializer;

        _mode = mode;
    }

    public object? Deserialize(string path, Type type)
    {
        using Stream stream = _explorer.Locate(new FilePath(path)).Open(_mode, FileAccess.Read);

        return _deserializer.Deserialize(stream, type);
    }

    public T? Deserialize<T>(string path)
    {
        using Stream stream = _explorer.Locate(new FilePath(path)).Open(_mode, FileAccess.Read);

        return _deserializer.Deserialize<T>(stream);
    }
}
