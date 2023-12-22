using System.IO;

namespace Senkel.IO.Terminals;

/// <summary>
/// Grants access on file-related system operations.
/// </summary>
public interface IFileTerminal : IPathTerminal
{   
    /// <summary>
    /// Exposes the instance methods for creating, deleting and other file-related functionality of the file based on the input path.
    /// </summary>
    /// <param name="path">The path of the file to expose.</param>
    /// <returns>The <see cref="FileInfo"/> object that exposes the file.</returns>
    public new FileInfo Expose(string path);

    /// <summary>
    /// Creates or overwrites a file at the specified path, specifying a buffer size.
    /// </summary>
    /// <param name="path">The path of the file to create.</param>
    /// <param name="bufferSize">The number of bytes buffered for reads and writes to the created file.</param>
    /// <returns>A <see cref="FileStream"/> with the specified buffer size that provides read/write access to the created file.</returns> 
    public FileStream Create(string path, int bufferSize = 4096);

    /// <summary>
    /// Opens an existing file or creates a new file for writing at the specified path.
    /// </summary>
    /// <param name="path">The path of the file..</param>
    /// <returns>An unshared <see cref="FileStream"/> object based on the specified path.</returns>
    public FileStream OpenWrite(string path);

    /// <summary>
    /// Opens an existing file for reading.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>A read-only <see cref="FileStream"/> object based on the specified path.</returns>
    public FileStream OpenRead(string path);
}