using Senkel.Model.Decorating;

namespace Senkel.IO.Paths;

/// <summary>
/// Implements the <see cref="IDuplexDecorator{T}"/> interface for decorating other subpaths of the directory corresponding to the represented path.
/// </summary>
public class DirectoryPath : DuplexDecorator<string>, IDirectoryPath
{
    private readonly object _path;

    /// <summary>
    /// Creates a new instance of the <see cref="DirectoryPath"/> class that uses the specified path as a representation of the corresponding directory.
    /// </summary>
    /// <param name="path">The path of the directory to represent that is determined by the <see cref="object.ToString"/> method.</param>
    public DirectoryPath(object path) : base()
    {  
        _path = path;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="DirectoryPath"/> class that uses the specified path as a representation of the corresponding directory.
    /// </summary>
    /// <param name="pathDecorator">The path decorator that the path of the represented directory is decorated by.</param>
    /// <param name="path">The path of the directory to represent that is determined by the <see cref="object.ToString"/> method.</param>
    public DirectoryPath(IDuplexDecorator<string> pathDecorator, object path) : base(pathDecorator)
    {
        _path = path;
    }

    /// <inheritdoc/>
    public string Value => _path.ToString()!;

    /// <summary>
    /// Decorates by joining the input string to the directory path captured in the <see cref="Value"/> property.
    /// </summary>
    /// <param name="value">The string value to join to the directory path.</param>
    /// <returns>The resulting string consisting of the input string joined to the path of the represented directory.</returns>
    public override string Decorate(string value)
    {
        return base.Decorate(Path.Join(Value, value));
    }

    /// <summary>
    /// Returns the <see cref="Value"/> property value of the object which is the represented path of a directory.
    /// </summary> 
    public sealed override string ToString()
    {
        return Value;
    }
}
