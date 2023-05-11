namespace Fontia;

/// <summary>
/// Represents a language-tag record in the naming table of a OpenType font.
/// </summary>
public class OpenTypeFontLanguageTagRecord
{
    /// <summary>
    /// Gets or sets the length of the language-tag string in bytes.
    /// </summary>
    public ushort Length { get; set; }

    /// <summary>
    /// Gets or sets the offset of the language-tag string from the start of the storage area in bytes.
    /// </summary>
    public ushort Offset { get; set; }

    /// <summary>
    /// Gets or sets the language-tag string.
    /// </summary>
    /// <remarks>
    /// The language-tag string represents a BCP 47 language tag that identifies the language, including dialects, written form, and other language variants.
    /// </remarks>
    public string LanguageTag { get; set; }
}