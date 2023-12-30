using System.IO;

namespace Senkel.IO.Systems;

public interface ISystemDirectory : ISystemEntry
{
    public void Create();

    public void Delete(bool recursive);
}