using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Senkel.IO.Paths;

/// <summary>
/// Represents a file at the specified path that can be based on an <see cref="IDuplexDecorator{T}"/> object for decorating the path.
/// </summary>
public class FilePath : DuplexDecorable<string>, ISystemPath
{ 
    private readonly string _path;

    /// <summary>
    /// Creates a new instance of the <see cref="FilePath"/> class where the specified path is decorated by the given <see cref="IDuplexDecorator{T}"/> object.
    /// </summary>
    /// <param name="pathDecorator">The path decorator that the path of the represented file is decorated by.</param>
    /// <param name="path">The path that is decorated by the given <see cref="IDuplexDecorator{T}"/> object.</param>
    public FilePath(IDuplexDecorator<string> pathDecorator, string path) : base(pathDecorator)
    { 
        _path = path;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="FilePath"/> class with the specified path.
    /// </summary> 
    /// <param name="path">The path that represents the file of the <see cref="FilePath"/>.</param>
    public FilePath(string path) : base()
    {
        _path = path;
    }

    /// <summary>
    /// Returns the <see cref="Path"/> property value of the object which is the represented path of a file.
    /// </summary> 
    public sealed override string ToString()
    {
        return Path;
    }
      
    /// <inheritdoc/>
    public string Path => Decorate(_path);
}
