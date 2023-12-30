using Senkel.IO.Paths;

namespace Senkel.IO.Systems;

public interface IDirectoryExplorer : ISystemExplorer
{
    public new ISystemDirectory Locate(ISystemPath path);
}