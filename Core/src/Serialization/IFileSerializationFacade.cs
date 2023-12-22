
using System.Runtime.CompilerServices;

namespace Senkel.IO.Serialization;
 
/// <summary>
/// Represents a facade that consists of a file serializer and a file deserializer. Both serializers should handle input paths in the same way.
/// </summary>
public interface IFileSerializationFacade
{
    /// <summary>
    /// The serializer of the facade.
    /// </summary>
    public IFileSerializer Serializer { get; init; }
     
    /// <summary>
    /// The deserializer of the facade.
    /// </summary>
    public IFileDeserializer Deserializer { get; init; }

}
