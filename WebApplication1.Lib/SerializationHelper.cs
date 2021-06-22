using ProtoBuf;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace WebApplication1.Lib
{
    internal static class SerializationHelper
    {
        public static byte[] ToByteArray<T>(T input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            using MemoryStream stream = new();
            Serializer.Serialize(stream, input);
            return stream.ToArray();
        }

        [return: MaybeNull]
        public static T FromByteArray<T>(byte[]? input)
        {
            if (input == null) return default;

            using MemoryStream stream = new(input);
            return Serializer.Deserialize<T>(stream);
        }
    }
}
