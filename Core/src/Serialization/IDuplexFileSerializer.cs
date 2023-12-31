
using System.Runtime.CompilerServices;

namespace Senkel.IO.Serialization;

/// <summary>
/// Represents a file serializer that is capable of both serialization and deserialization.
/// </summary>
public interface IDuplexFileSerializer : IFileDeserializer, IFileSerializer { }

