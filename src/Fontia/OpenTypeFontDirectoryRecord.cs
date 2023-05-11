namespace Fontia;

/// <summary>
/// Represents a record in the table directory of a OpenType font.
/// A table record provides information about a top-level table in the font.
/// </summary>
public class OpenTypeFontDirectoryRecord
{
    /// <summary>
    /// Gets the tag identifying the table.
    /// </summary>
    public OpenTypeFontTableTag Tag { get; }

    /// <summary>
    /// Gets the checksum value for the table.
    /// </summary>
    public uint Checksum { get; }

    /// <summary>
    /// Gets the offset of the table from the beginning of the font file.
    /// </summary>
    public uint Offset { get; }

    /// <summary>
    /// Gets the length of the table data in bytes.
    /// </summary>
    public uint Length { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenTypeFontDirectoryRecord"/> class.
    /// </summary>
    /// <param name="tag">The tag identifying the table.</param>
    /// <param name="checksum">The checksum value for the table.</param>
    /// <param name="offset">The offset of the table from the beginning of the font file.</param>
    /// <param name="length">The length of the table data in bytes.</param>
    public OpenTypeFontDirectoryRecord(OpenTypeFontTableTag tag, uint checksum, uint offset, uint length)
    {
        Tag = tag;
        Checksum = checksum;
        Offset = offset;
        Length = length;
    }
}