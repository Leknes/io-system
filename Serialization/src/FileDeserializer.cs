using Senkel.Serialization;
using Senkel.IO.Paths;
using Senkel.IO.Terminals;
using System.IO;
using System;

namespace Senkel.IO.Serialization;

/// <summary>
/// Represents a deserializer that is capable of deserializing an object from a file using an initially set <see cref="IFileTerminal"/> object 
/// and an <see cref="IStreamDeserializer"/> deserializer.
/// </summary>
public class FileDeserializer : IFileDeserializer
{
    private readonly IStreamDeserializer _deserializer;
    private readonly IFileTerminal _terminal;

    /// <summary>
    /// Creates a new instance of the <see cref="FileDeserializer"/> class that uses the specified <see cref="IStreamDeserializer"/> object for deserializing
    /// and the given <see cref="IFileTerminal"/> for reading files.
    /// </summary>
    /// <param name="terminal">The terminal to use for reading files.</param>
    /// <param name="deserializer">The deserializer to use for deserializing files.</param>
    public FileDeserializer(IFileTerminal terminal, IStreamDeserializer deserializer)
    {
        _deserializer = deserializer; 
        _terminal = terminal;
    }

    private FileStream OpenFile(string path)
    {
        return _terminal.OpenRead(path);
    }

    /// <summary>
    /// Deserializes an object of the specified type from the file at the specified path determined by an <see cref="IFileTerminal"/> object.
    /// </summary> 
    /// <inheritdoc/>

    public T? Deserialize<T>(string path)
    {
        using FileStream stream = OpenFile(path);

        return _deserializer.Deserialize<T>(stream);
    }

    /// <summary>
    /// Deserializes an object of the specified type from the file at the specified path determined by an <see cref="IFileTerminal"/> object.
    /// </summary> 
    /// <inheritdoc/>
    public object? Deserialize(string path, Type type)
    {
        using FileStream stream = OpenFile(path);

        return _deserializer.Deserialize(stream, type);
    }
     
}
 
