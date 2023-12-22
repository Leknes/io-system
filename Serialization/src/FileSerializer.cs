using Senkel.Serialization;
using Senkel.IO.Paths; 
using Senkel.IO.Terminals;
using System.IO;

namespace Senkel.IO.Serialization;

/// <summary>
/// Represents a file serializer that serializes files based on an initially set <see cref="IFileTerminal"/> object and an <see cref="IStreamSerializer"/> serializer.
/// </summary>
public class FileSerializer : IFileSerializer
{
    private readonly IStreamSerializer _serializer;

    private readonly IFileTerminal _terminal;
      
    /// <summary>
    /// Creates a new instance of the <see cref="FileSerializer"/> class that uses the specified <see cref="IFileTerminal"/> object for serializing files based on their paths.
    /// </summary>
    /// <param name="terminal">The terminal that is for writing to files.</param>
    /// <param name="serializer">The serializer to use for serializing files.</param>
    public FileSerializer(IFileTerminal terminal, IStreamSerializer serializer)
    {
        _serializer = serializer;
        _terminal = terminal;
    }

    /// <summary>
    /// Serializes the given object into the file at the specified path determined by the initially set <see cref="IFileTerminal"/> object 
    /// and creates the parent directory of the file unless it already exists.
    /// </summary>
    /// <inheritdoc/>
    public void Serialize(string path, object? value)
    {
        FileInfo info = _terminal.Expose(path);
         
        info.CreateParentDirectory();

        using FileStream stream = info.OpenWrite();

        _serializer.Serialize(stream, value);
    } 
}
