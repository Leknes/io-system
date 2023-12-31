using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senkel.IO.Serialization;

/// <summary>
/// Respresents a serializer that is capable of serializing objects into files.
/// </summary>
public interface IFileSerializer
{
    /// <summary>
    /// Serializes the specified value into the file at the given path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <param name="value">The value to serialize.</param>
    public void Serialize(string path, object? value);
}
