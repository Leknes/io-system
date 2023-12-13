using Senkel.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senkel.ObjectModel.Decorating;

namespace Senkel.IO.Paths.Serialization;

/// <summary>
/// Represents a deserializer that is capable of deserializing a file using the specified <see cref="IStreamDeserializer"/> object, 
/// based on a provided <see cref="IValueDecorator{T}"/> object.
/// </summary>
public class PathDeserializer : ValueDecorable<string>
{
    private readonly IStreamDeserializer _deserializer; 

    /// <summary>
    /// Creates a new instance of the <see cref="PathDeserializer"/> class that uses the specified <see cref="IStreamDeserializer"/> object for deserializing
    /// and the given <see cref="IValueDecorator{T}"/> object as a decorator for input paths.
    /// </summary>
    /// <param name="pathDecorator">The decorator that an input path will be decorated with.</param>
    /// <param name="deserializer">The deserializer to use for deserializing files.</param>
    public PathDeserializer(IValueDecorator<string> pathDecorator, IStreamDeserializer deserializer) : base(pathDecorator)
    {
        _deserializer = deserializer; 
    }

    /// <summary>
    /// Creates a new instance of the <see cref="PathDeserializer"/> class that uses the specified <see cref="IStreamDeserializer"/> object for deserializing objects.
    /// </summary>
    /// <param name="deserializer">The deserializer to use for deserializing files.</param>
    public PathDeserializer(IStreamDeserializer deserializer) : base()
    {
        _deserializer = deserializer;
    }

    /// <summary>
    /// Deserializes an object of the specified type from the file at the given path decorated by the initially set <see cref="IValueDecorator{T}"/> decorator if one has been specified.
    /// </summary>
    /// <param name="path">The decorable path of the location to deserialize.</param>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <returns>The deserialized object.</returns>
    public T? Deserialize<T>(string path)
    {
       return Deserialize<T>(Decorate(path));
    }

    /// <summary>
    /// Deserializes an object of the specified type from the file at the given path decorated by the initially set <see cref="IValueDecorator{T}"/> decorator if one has been specified.
    /// </summary>
    /// <param name="path">The decorable path of the location to deserialize.</param>
    /// <param name="type">The type of the object to deserialize.</param>
    /// <returns>The deserialized object.</returns>
    public object? Deserialize(string path, Type type)
    { 
       return _deserializer.DeserializeFile(Decorate(path), type);
    }
     
}
 
