using System.IO;

namespace Senkel.IO.Systems;

public interface ISystemFile : ISystemEntry
{
    public Stream Create();
    
    public Stream Open(FileMode mode = FileMode.OpenOrCreate, FileAccess access = FileAccess.ReadWrite);
}