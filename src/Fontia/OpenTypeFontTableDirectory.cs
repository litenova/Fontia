using System.Collections;

namespace Fontia;

/// <summary>
/// Represents the OpenType Table Directory.
/// The table directory contains information about the top-level tables in the font.
/// </summary>
public class OpenTypeFontTableDirectory : IReadOnlyCollection<OpenTypeFontDirectoryRecord>
{
    /// <summary>
    /// Gets or sets the sfnt version of the font.
    /// </summary>
    /// <remarks>
    /// The sfnt version should be 0x00010000 for TrueType outlines and 0x4F54544F ('OTTO') for CFF data.
    /// The term "sfnt" refers to the underlying file structure or wrapper format used to organize and store font data.
    /// It provides a standardized structure for storing fonts, including both TrueType and PostScript-based OpenType fonts.
    /// The sfnt format allows fonts to accommodate various tables and data formats, enabling extensibility and cross-platform compatibility.
    /// </remarks>
    public uint SfntVersion { get; }

    /// <summary>
    /// Gets the number of table records in the OpenType font directory.
    /// </summary>
    public int Count => _records.Count;

    /// <summary>
    /// Gets or sets the maximum power of 2 less than or equal to <see cref="Count"/> times 16.
    /// </summary>
    /// <remarks>
    /// This field is used in binary searches for table lookup and should be calculated as (2^Floor(Log2(NumTables))) * 16.
    /// </remarks>
    public ushort SearchRange { get; }

    /// <summary>
    /// Gets or sets the log2 of the maximum power of 2 less than or equal to <see cref="Count"/>.
    /// </summary>
    /// <remarks>
    /// This field is used in binary searches for table lookup and should be calculated as Log2(SearchRange/16), which is equal to Floor(Log2(NumTables)).
    /// </remarks>
    public ushort EntrySelector { get; }

    /// <summary>
    /// Gets or sets the number of entries that need to be searched after a binary search of <see cref="SearchRange"/>.
    /// </summary>
    /// <remarks>
    /// This field is used in binary searches for table lookup and should be calculated as (NumTables * 16) - SearchRange.
    /// </remarks>
    public ushort RangeShift { get; }

    private readonly Dictionary<OpenTypeFontTableTag, OpenTypeFontDirectoryRecord> _records;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenTypeFontTableDirectory"/> class by reading the table directory from a OpenType font file.
    /// </summary>
    /// <param name="binaryReader">The binary reader to read the table directory from.</param>
    public OpenTypeFontTableDirectory(BinaryReader binaryReader)
    {
        _records = new Dictionary<OpenTypeFontTableTag, OpenTypeFontDirectoryRecord>();

        // Read the table directory header
        binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);
        SfntVersion = binaryReader.ReadUInt32BigEndian();
        var numTables = binaryReader.ReadUInt16BigEndian();
        SearchRange = binaryReader.ReadUInt16BigEndian();
        EntrySelector = binaryReader.ReadUInt16BigEndian();
        RangeShift = binaryReader.ReadUInt16BigEndian();

        // Read each table record
        for (var i = 0; i < numTables; i++)
        {
            var tag = (OpenTypeFontTableTag) binaryReader.ReadUInt32BigEndian();
            var checksum = binaryReader.ReadUInt32BigEndian();
            var offset = binaryReader.ReadUInt32BigEndian();
            var length = binaryReader.ReadUInt32BigEndian();

            _records[tag] = new OpenTypeFontDirectoryRecord(tag, checksum, offset, length);
        }
    }

    /// <summary>
    /// Gets the table record for the specified table tag.
    /// </summary>
    /// <param name="tag">The table tag.</param>
    /// <returns>The table record for the specified table tag.</returns>
    public OpenTypeFontDirectoryRecord this[OpenTypeFontTableTag tag] => _records[tag];

    /// <summary>
    /// Returns an enumerator that iterates through the table records in the OpenType font directory.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the table records.</returns>
    public IEnumerator<OpenTypeFontDirectoryRecord> GetEnumerator() => _records.Values.GetEnumerator();

    /// <summary>
    /// Returns an enumerator that iterates through the table records in the OpenType font directory.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the table records.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}