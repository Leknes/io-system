using System.IO;
using Senkel.IO.Paths;

namespace Senkel.IO.Terminals
{
    /// <summary>
    /// Represents a manager that is capable of managing files or directories based on their paths.
    /// </summary>
    public interface IPathTerminal
    {
        /// <summary>
        /// Exposes the instance methods for creating, deleting and other system-related functionality based on the input path.
        /// </summary>
        /// <param name="path">The path of the file or directory to expose.</param>
        /// <returns>A <see cref="FileSystemInfo"/> object that is based on the input path.</returns>
        public FileSystemInfo Expose(string path);
       
        /// <summary>
        /// Creates a new <see cref="ISystemPath"/> object that is based on the specified path.
        /// </summary>
        /// <param name="path">The path to derive an <see cref="ISystemPath"/> object from.</param>
        /// <returns>The created <see cref="ISystemPath"/> object.</returns>
        public ISystemPath Derive(object path);

        /// <summary>
        /// Deletes the file or directory at the specified path.
        /// </summary>
        /// <param name="path">The used path.</param>
        public void Delete(string path);

        /// <summary>
        /// Determines if a file or directory exists at the specified path.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns>If the file or directory exists.</returns>
        public bool Exists(string path);

        /// <summary>
        /// Moves the file or directory at the specified source path to the specified destination path.
        /// This method may also be used for renaming a file or directory.
        /// </summary>
        /// <param name="sourcePath">The source path of the file or directory to move.</param>
        /// <param name="destinationPath">Where to move the file or directory.</param>
        public void Move(string sourcePath, string destinationPath);
         
    }
}
