using System; 

namespace Senkel.IO.Serialization;

/// <summary>
/// Represents a deserializer that is capable of deserializing objects from files.
/// </summary>
public interface IFileDeserializer
{
    /// <summary>
    /// Deserializes an object of the specified type from the file at the specified path.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="path">The path of the file to deserialize from.</param>
    /// <returns>The deserialized object.</returns>
    public T? Deserialize<T>(string path);

    /// <summary>
    /// Deserializes an object of the specified type from the file at the specified path.
    /// </summary>
    /// <param name="type">The type of the object to deserialize.</param>
    /// <param name="path">The path of the file to deserialize from.</param>
    /// <returns>The deserialized object.</returns>
    public object? Deserialize(string path, Type type);
}
