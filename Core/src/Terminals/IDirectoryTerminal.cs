using Senkel.IO.Paths;

namespace Senkel.IO.Terminals;

/// <summary>
/// Grants access on directory-related system operations.
/// </summary>
public interface IDirectoryTerminal : IPathTerminal
{    
    /// <summary>
    /// Exposes the instance methods for creating, deleting and other directory-related functionality of the directory based on the input path.
    /// </summary>
    /// <param name="path">The path of the directory to expose.</param>
    /// <returns>The <see cref="DirectoryInfo"/> object that exposes the directory.</returns>
    public new DirectoryInfo Expose(string path);

    /// <summary>
    /// Creates a new <see cref="IDirectoryPath"/> object that is based on the input path.
    /// </summary>
    /// <param name="path">The path of the <see cref="IDirectoryPath"/> object to derive.</param>
    /// <returns>The created <see cref="IDirectoryPath"/> instance.</returns>
    public new IDirectoryPath Derive(object path);
     
    public void Delete(string path, bool recursive);
}