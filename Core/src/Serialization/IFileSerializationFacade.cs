using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senkel.IO.Serialization
{
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
}
