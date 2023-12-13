using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senkel.IO.Paths;

/// <summary>
/// Represents a path that leads to a directory or to a file.
/// </summary>
public interface IPath
{
    /// <summary>
    /// The path leading to the represented directory or path.
    /// </summary>
    public abstract string Value { get; }
}
