using Senkel.ObjectModel.Decorating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senkel.IO.Paths;

/// <summary>
/// Implements the <see cref="IValueDecorator{T}"/> interface for decorating other subpaths of the directory corresponding to the represented path.
/// </summary>
public class DirectoryPath : ValueDecorator<string>, IPath
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
    public DirectoryPath(IValueDecorator<string> pathDecorator, object path) : base(pathDecorator)
    {
        _path = path;
    }

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
