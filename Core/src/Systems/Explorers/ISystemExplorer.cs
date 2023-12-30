using Senkel.IO.Paths;

namespace Senkel.IO.Systems;

public interface ISystemExplorer
{
    public void Move(string sourcePath, string destinationPath);

    public ISystemEntry Locate(ISystemPath path);
}