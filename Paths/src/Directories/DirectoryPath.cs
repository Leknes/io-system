global using System.IO;

using Senkel;

namespace Senkel.IO.Paths;

/// <summary>
/// Implements the <see cref="IDuplexDecorator{T}"/> interface for decorating other subpaths of the directory corresponding to the represented path.
/// </summary>
public class DirectoryPath : DuplexDecorator<string>, IDirectoryPath
{
    private readonly string _path;

    /// <summary>
    /// Creates a new instance of the <see cref="DirectoryPath"/> class that uses the specified path as a representation of the corresponding directory.
    /// </summary>
    /// <param name="path">The path of the directory to represent.</param>
    public DirectoryPath(string path) : base()
    {  
        _path = path;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="DirectoryPath"/> class that uses the specified path as a representation of the corresponding directory.
    /// </summary>
    /// <param name="pathDecorator">The path decorator that the path of the represented directory is decorated by.</param>
    /// <param name="path">The path of the directory to represent.</param>
    public DirectoryPath(IDuplexDecorator<string> pathDecorator, string path) : base(pathDecorator)
    {
        _path = path;
    }

    /// <inheritdoc/>
    public string Path => _path;

    /// <summary>
    /// Decorates by joining the input string to the directory path captured in the <see cref="Path"/> property.
    /// </summary>
    /// <param name="value">The string value to join to the directory path.</param>
    /// <returns>The resulting string consisting of the input string joined to the path of the represented directory.</returns>
    public override string Decorate(string value)
    {
        return base.Decorate(System.IO.Path.Join(Path, value));
    }
     
}
