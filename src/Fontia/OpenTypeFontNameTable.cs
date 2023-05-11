using System.Collections;

namespace Fontia;

public class OpenTypeFontNameTable : IReadOnlyCollection<OpenTypeFontNameTableRecord>
{
    /// <summary>
    /// Gets the table version number.
    /// </summary>
    public ushort Version { get; }

    /// <summary>
    /// Gets the offset to start of string storage.
    /// </summary>
    public ushort StorageOffset { get; }

    private readonly Dictionary<ushort, OpenTypeFontNameTableRecord> _nameRecords;

    /// <summary>
    /// Gets the number of name records.
    /// </summary>
    public int Count => _nameRecords.Count;

    /// <summary>
    /// Gets the name record for the specified name ID.
    /// </summary>
    /// <param name="nameId">The name ID of the record to retrieve.</param>
    /// <returns>The name record with the specified name ID.</returns>
    public OpenTypeFontNameTableRecord this[OpenTypeFontNameId nameId] => _nameRecords[(ushort) nameId];

    /// <summary>
    /// Gets the name record for the specified name ID.
    /// </summary>
    /// <param name="nameId">The name ID of the record to retrieve.</param>
    /// <returns>The name record with the specified name ID.</returns>
    public OpenTypeFontNameTableRecord this[ushort nameId] => _nameRecords[nameId];

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenTypeFontNameTable"/> class by reading the name table from a OpenType font file.
    /// </summary>
    /// <param name="binaryReader">The binary reader to read the name table from.</param>
    /// <param name="nameTableOffset">The offset of the name table from the start of the font file.</param>
    public OpenTypeFontNameTable(BinaryReader binaryReader, uint nameTableOffset)
    {
        binaryReader.BaseStream.Seek(nameTableOffset, SeekOrigin.Begin);

        Version = binaryReader.ReadUInt16BigEndian();
        var recordCount = binaryReader.ReadUInt16BigEndian();
        StorageOffset = binaryReader.ReadUInt16BigEndian();

        _nameRecords = new Dictionary<ushort, OpenTypeFontNameTableRecord>();

        for (var i = 0; i < recordCount; i++)
        {
            var platformID = binaryReader.ReadUInt16BigEndian();
            var encodingID = binaryReader.ReadUInt16BigEndian();
            var languageID = binaryReader.ReadUInt16BigEndian();
            var nameID = binaryReader.ReadUInt16BigEndian();
            var length = binaryReader.ReadUInt16BigEndian();
            var offset = binaryReader.ReadUInt16BigEndian();

            //_nameRecords[nameEnumId] = new OpenTypeFontNameTableRecord(platformID, encodingID, languageID, nameID, length, offset);
        }
    }

    /// <summary>
    /// Gets an enumerator that iterates through the name records.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the name records.</returns>
    public IEnumerator<OpenTypeFontNameTableRecord> GetEnumerator() => _nameRecords.Values.GetEnumerator();

    /// <summary>
    /// Gets an enumerator that iterates through the name records.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the name records.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}