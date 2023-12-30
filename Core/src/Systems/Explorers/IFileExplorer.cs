using Senkel.IO.Paths;

namespace Senkel.IO.Systems;

public interface IFileExplorer : ISystemExplorer
{
    public new ISystemFile Locate(ISystemPath path);

    public void Copy(string sourcePath, string destinationPath, bool overwrite = false);
}