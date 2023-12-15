using Senkel.Model.Decorating;
using Senkel.IO.Paths;

namespace Senkel.IO.Terminals
{
    /// <summary>
    /// Represents a manager that is capable of managing directories with paths that are modified by the initally set <see cref="IDuplexDecorator{T}"/> decorator.
    /// </summary>
    public class DirectoryTerminal : DuplexDecorable<string>, IDirectoryTerminal
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DirectoryTerminal"/> class that modifies paths based on the specified path decorator.
        /// </summary>
        /// <param name="pathDecorator">The path decorator that is used for modifying every path this manager works with.</param>
        public DirectoryTerminal(IDuplexDecorator<string> pathDecorator) : base(pathDecorator) { }
      
        /// <summary>
        /// Creates a new instance of the <see cref="DirectoryTerminal"/> class that does not modify any input paths. 
        /// </summary>
        public DirectoryTerminal() : base() { }

        FileSystemInfo IPathTerminal.Expose(string path) => Expose(path);
        ISystemPath IPathTerminal.Derive(object path) => Derive(path);
        IDirectoryPath IDirectoryTerminal.Derive(object path) => Derive(path);

        /// <summary>
        /// Exposes the instance methods for creating, deleting and other directory-related functionality of the directory based on the modified input path.
        /// </summary>
        /// <param name="path">The modifiable path of the directory to expose.</param>
        /// <returns>The <see cref="DirectoryInfo"/> object that exposes the directory.</returns>
        public DirectoryInfo Expose(string path)
        {
            return new DirectoryInfo(Decorate(path));
        }

        /// <summary>
        /// Creates a new <see cref="DirectoryPath"/> object that is based on the modified input path.
        /// </summary>
        /// <param name="path">The modifiable path of the <see cref="DirectoryPath"/> object to derive.</param>
        /// <returns>The created <see cref="DirectoryPath"/> instance.</returns>
        public DirectoryPath Derive(object path)
        { 
            return new DirectoryPath(Decorator, path);
        }

        /// <summary>
        /// Creates all directories and sub-directories in the modified input path unless they already exist.
        /// </summary>
        /// <param name="path">The modifiable path of the directory to create.</param>
        /// <returns>An object that exposes the directory at the modified input path.</returns> 
        public DirectoryInfo Create(string path)
        {
            return Directory.CreateDirectory(Decorate(path));
        }
          
        /// <summary>
        /// Deletes an empty directory at the specified modified path.
        /// </summary>
        /// <param name="path">The modifiable path of the directory to delete.</param> 
        public void Delete(string path)
        {
            Directory.Delete(Decorate(path));
        }

        /// <summary>
        /// Deletes the directory at the modified input path and, if indicated, every any subdirectories and files in the directory.
        /// </summary>
        /// <param name="path">The modifiable path of the directory to delete.</param>
        /// <param name="recursive">If any subdirectories and files in the directory should be deleted as well.</param>
        public void Delete(string path, bool recursive)
        {
            Directory.Delete(Decorate(path), recursive);
        }

        /// <summary>
        /// Determines wether the directory at the modified input path exists or not.
        /// </summary>
        /// <param name="path">The modifiable path of the directory to check.</param>
        /// <returns>If the directory exists.</returns>
        public bool Exists(string path)
        {
            return Directory.Exists(Decorate(path));
        }

        /// <summary>
        /// Moves the directory at the modified source path to the modified destination path. 
        /// This method can also be used for renaming a directory.
        /// </summary>
        /// <param name="sourcePath">The modifiable source path of the directory.</param>
        /// <param name="destinationPath">The modifiable path of where to move the directory.</param>
        public void Move(string sourcePath, string destinationPath)
        {
            Directory.Move(Decorate(sourcePath), Decorate(destinationPath));
        }

    }
}
