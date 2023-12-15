using Senkel.IO.Paths;
using Senkel.Model.Decorating;
 
namespace Senkel.IO.Terminals
{
    /// <summary>
    /// Represents a manager that is capable of managing files with paths that are modified by the initally set <see cref="IDuplexDecorator{T}"/> decorator.
    /// </summary>
    public class FileTerminal : DuplexDecorable<string>, IFileTerminal
    {
        /// <summary>
        /// Creates a new instance of the <see cref="FileTerminal"/> class that modifies paths based on the specified path decorator.
        /// </summary>
        /// <param name="pathDecorator">The path decorator that is used for modifying every path this manager works with.</param>
        public FileTerminal(IDuplexDecorator<string> pathDecorator) : base(pathDecorator) { }

        /// <summary>
        /// Creates a new instance of the <see cref="FileTerminal"/> class that does not modify any input paths. 
        /// </summary>
        public FileTerminal() : base() { }

        FileSystemInfo IPathTerminal.Expose(string path) => Expose(path);
        ISystemPath IPathTerminal.Derive(object path) => Derive(path);
    
        /// <summary>
        /// Exposes the instance methods for creating, deleting and other file-related functionality of the file based on the modified input path.
        /// </summary>
        /// <param name="path">The modifiable path of the file to expose.</param>
        /// <returns>The <see cref="FileInfo"/> object that exposes the file.</returns>
        public FileInfo Expose(string path)
        { 
            return new FileInfo(Decorate(path));
        }

        /// <summary>
        /// Creates a new <see cref="FilePath"/> object that is based on the modified input path.
        /// </summary>
        /// <param name="path">The modifiable path of the <see cref="FilePath"/> object to derive.</param>
        /// <returns>The created <see cref="FilePath"/> instance.</returns>
        public FilePath Derive(object path)
        {
            return new FilePath(Decorator, path);
        }
         
        /// <summary>
        /// Creates or overwrites a file at the specified modified path, specifying a buffer size.
        /// </summary>
        /// <param name="path">The modifiable path of the file to create.</param>
        /// <param name="bufferSize">The number of bytes buffered for reads and writes to the created file.</param>
        /// <returns>A <see cref="FileStream"/> with the specified buffer size that provides read/write access to the created file.</returns> 
        public FileStream Create(string path, int bufferSize = 4096)
        { 
            return File.Create(Decorate(path), bufferSize);
        }
         
        /// <summary>
        /// Opens an existing file for reading.
        /// </summary>
        /// <param name="path">The modifiable path.</param>
        /// <returns>A read-only <see cref="FileStream"/> object on the specified path.</returns>
        public FileStream OpenRead(string path)
        {
            return File.OpenRead(Decorate(path));
        }

        /// <summary>
        /// Opens an existing file or creates a new file for writing at the modified path.
        /// </summary>
        /// <param name="path">The modifiable path.</param>
        /// <returns>An unshared <see cref="FileStream"/> object on the specified path.</returns>
        public FileStream OpenWrite(string path)
        { 
            return File.OpenWrite(Decorate(path));
        }
          
        /// <summary>
        /// Deletes the file at the modified inpuit path.
        /// </summary>
        /// <param name="path">The modifiable path of the file to delete.</param> 
        public void Delete(string path)
        {
            File.Delete(Decorate(path));
        }

        /// <summary>
        /// Determines wether the file at the modified input path exists or not.
        /// </summary>
        /// <param name="path">The modifiable path of the file to check.</param>
        /// <returns><see langword="true"/> if the file exists and the caller has the required permissions for getting the file. <see langword="false"/> otherwise, or if the path is not valid, empty or null. </returns>
        public bool Exists(string path)
        {
            return File.Exists(Decorate(path));
        }

        /// <summary>
        /// Moves the file at the modified source path to the modified destination path. 
        /// This method can also be used for renaming a file.
        /// </summary>
        /// <param name="sourcePath">The modifiable source path of the file.</param>
        /// <param name="destinationPath">The modifiable path of where to move the file.</param>
        public void Move(string sourcePath, string destinationPath)
        {
            File.Move(Decorate(sourcePath), Decorate(destinationPath));
        }

    }
}
