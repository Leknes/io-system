using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senkel.IO.Paths;
 
/// <summary>
/// Represents the path of a directory.
/// </summary>
public interface IDirectoryPath : ISystemPath, IDuplexDecorator<string> 
{ 
    /// <summary>
    /// The path of the directory.
    /// </summary>
    public new string Value { get; } 
}

