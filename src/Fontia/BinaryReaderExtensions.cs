using System.Buffers.Binary;

namespace Fontia;

public static class BinaryReaderExtensions
{
    public static uint ReadUInt32BigEndian(this BinaryReader binaryReader)
    {
        return BinaryPrimitives.ReadUInt32BigEndian(binaryReader.ReadBytes(sizeof(uint)));
    }

    public static ushort ReadUInt16BigEndian(this BinaryReader binaryReader)
    {
        return BinaryPrimitives.ReadUInt16BigEndian(binaryReader.ReadBytes(sizeof(ushort)));
    }
}