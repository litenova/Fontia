namespace Fontia;

/// <summary>
/// Represents a name record in the naming table of a OpenType font.
/// </summary>
public class OpenTypeFontNameTableRecord
{
    /// <summary>
    /// Gets or sets the platform ID associated with the name record.
    /// </summary>
    public ushort PlatformId { get; set; }

    /// <summary>
    /// Gets or sets the platform-specific encoding ID associated with the name record.
    /// </summary>
    public ushort EncodingId { get; set; }

    /// <summary>
    /// Gets or sets the language ID associated with the name record.
    /// </summary>
    public ushort LanguageId { get; set; }

    /// <summary>
    /// Gets or sets the name ID that identifies the logical string category.
    /// </summary>
    public ushort NameId { get; set; }

    /// <summary>
    /// Gets or sets the length of the string in bytes.
    /// </summary>
    public ushort Length { get; set; }

    /// <summary>
    /// Gets or sets the offset of the string from the start of the storage area in bytes.
    /// </summary>
    public ushort StringOffset { get; set; }

    /// <summary>
    /// Gets or sets the string value associated with the name record.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenTypeFontNameTableRecord"/> class.
    /// </summary>
    /// <param name="platformId">The platform ID associated with the name record.</param>
    /// <param name="encodingId">The platform-specific encoding ID associated with the name record.</param>
    /// <param name="languageId">The language ID associated with the name record.</param>
    /// <param name="nameId">The name ID that identifies the logical string category.</param>
    /// <param name="length">The length of the string in bytes.</param>
    /// <param name="stringOffset">The offset of the string from the start of the storage area in bytes.</param>
    /// <param name="value">The string value associated with the name record.</param>
    public OpenTypeFontNameTableRecord(ushort platformId, ushort encodingId, ushort languageId, ushort nameId, ushort length, ushort stringOffset, string value)
    {
        PlatformId = platformId;
        EncodingId = encodingId;
        LanguageId = languageId;
        NameId = nameId;
        Length = length;
        StringOffset = stringOffset;
        Value = value;
    }
}