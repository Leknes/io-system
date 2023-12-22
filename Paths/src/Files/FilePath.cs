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
    private readonly object _path;

    /// <summary>
    /// Creates a new instance of the <see cref="FilePath"/> class where the specified path is decorated by the given <see cref="IDuplexDecorator{T}"/> object.
    /// </summary>
    /// <param name="pathDecorator">The path decorator that the path of the represented file is decorated by.</param>
    /// <param name="path">The path that is decorated by the given <see cref="IDuplexDecorator{T}"/> object that is determined by the <see cref="object.ToString"/> method.</param>
    public FilePath(IDuplexDecorator<string> pathDecorator, object path) : base(pathDecorator)
    { 
        _path = path;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="FilePath"/> class with the specified path.
    /// </summary> 
    /// <param name="path">The path that represents the file of the <see cref="FilePath"/>.</param>
    public FilePath(object path) : base()
    {
        _path = path;
    }

    /// <summary>
    /// Returns the <see cref="Value"/> property value of the object which is the represented path of a file.
    /// </summary> 
    public sealed override string ToString()
    {
        return Value;
    }
      
    /// <inheritdoc/>
    public string Value => Decorate(_path.ToString()!);
}
