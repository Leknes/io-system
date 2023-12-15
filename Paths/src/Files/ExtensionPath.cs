using Senkel.Model.Decorating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senkel.IO.Paths;

/// <summary>
/// Represents an implementation of the <see cref="IDecorator{T}"/> interface that adds a the specified extension string, that is initialized in the constructor, to a path.
/// </summary>
public class ExtensionPath : DuplexDecorator<string>
{
    private object _extension;

    /// <summary>
    /// The extension that is used for extending a path.
    /// </summary>
    public string Extension => _extension.ToString()!;

    /// <summary>
    /// Creates a new instance of the <see cref="ExtensionPath"/> class that used the specified extension.
    /// </summary>
    /// <param name="extension">The file extension to be used by the class that is determined by the <see cref="object.ToString"/> method.</param>
    public ExtensionPath(object extension) : base()
    {
        _extension = extension;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ExtensionPath"/> class that used the specified extension.
    /// </summary>
    /// <param name="pathDecorator">The path decorator that the path with the corresponding extension is decorated by.</param>
    /// <param name="extension">The file extension to be used by the class that is determined by the <see cref="object.ToString"/> method.</param>
    public ExtensionPath(IDuplexDecorator<string> pathDecorator, object extension) : base(pathDecorator)
    {
        _extension = extension;
    }


    /// <summary>
    /// Decorates by returning a string with an added extension based on the <see cref="Extension"/> property.
    /// </summary>
    /// <param name="value">The string value to add an extension to.</param>
    /// <returns>The string with an extension added to it.</returns>
    public override string Decorate(string value)
    {  
        return base.Decorate($"{value}.{Extension}");
    }
}
