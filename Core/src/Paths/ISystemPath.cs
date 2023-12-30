using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senkel.IO.Paths;

/// <summary>
/// Represents a path of a directory or to a file.
/// </summary>
public interface ISystemPath
{
    /// <summary>
    /// The path of the corresponding directory or path.
    /// </summary>
    public abstract string Path { get; }
}
