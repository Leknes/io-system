using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senkel.ObjectModel.Decorating;
using Senkel.Serialization;

namespace Senkel.IO.Paths.Serialization;

/// <summary>
/// Represents a serializer that is capable of serializing to a file using the specified <see cref="IStreamSerializer"/> object, 
/// based on a provided <see cref="IValueDecorator{T}"/> decorator for decorating the input paths.
/// </summary>
public class PathSerializer : ValueDecorable<string>
{
    private readonly IStreamSerializer _serializer;

    /// <summary>
    /// Creates a new instance of the <see cref="PathSerializer"/> class that uses the specified <see cref="IStreamSerializer"/> object for serializing
    /// and the given <see cref="IValueDecorator{T}"/> object as a decorator for input paths.
    /// </summary>
    /// <param name="pathDecorator">The decorator that an input path will be decorated with.</param>
    /// <param name="serializer">The serializer to use for serializing files.</param>
    public PathSerializer(IValueDecorator<string> pathDecorator, IStreamSerializer serializer) : base(pathDecorator)
    {
        _serializer = serializer;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="PathSerializer"/> class that is capable of serializing objects by their path.
    /// </summary> 
    /// <param name="serializer">The serializer to use for serializing files.</param>
    public PathSerializer(IStreamSerializer serializer) : base()
    { 
        _serializer = serializer;
    }

    /// <summary>
    /// Serializes the given object into the file at the specified path decorated by the initially set <see cref="IValueDecorator{T}"/> decorator if one has been specified.
    /// </summary>
    /// <param name="path">The decorable path of the location to serialize..</param>
    /// <param name="value">The object to serialize.</param>
    /// <param name="createDirectory">If the directories should be created at the specified location, given, the do not already exist.</param>
    public void Serialize(string path, object? value, bool createDirectory = true)
    {
        _serializer.SerializeFile(Decorate(path), value, createDirectory);
    } 
}
