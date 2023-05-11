namespace Fontia;

/// <summary>
/// Represents the Name ID codes in OpenType fonts.
/// </summary>
/// <remarks>
/// The following name IDs are pre-defined, and they apply to all platforms unless indicated otherwise.
/// Name IDs 26 to 255, inclusive, are reserved for future standard names.
/// Name IDs 256 to 32767, inclusive, are reserved for font-specific names such as those referenced by a font’s layout features.
/// </remarks>
public enum OpenTypeFontNameId : ushort
{
    /// <summary>
    /// Copyright notice.
    /// </summary>
    CopyrightNotice = 0,

    /// <summary>
    /// Font Family name.
    /// The Font Family name is used in combination with Font Subfamily name (Name ID 2),
    /// and should be shared among at most four fonts that differ only in weight or style.
    /// </summary>
    FontFamily = 1,

    /// <summary>
    /// Font Subfamily name.
    /// The Font Subfamily name is used in combination with Font Family name (Name ID 1),
    /// and distinguishes the fonts in a group with the same Font Family name.
    /// </summary>
    FontSubfamily = 2,

    /// <summary>
    /// Unique font identifier.
    /// </summary>
    UniqueFontIdentifier = 3,

    /// <summary>
    /// Full font name that reflects all family and relevant subfamily descriptors.
    /// The full font name is generally a combination of name IDs 1 and 2, or of name IDs 16 and 17, or a similar human-readable variant.
    /// </summary>
    FullFontName = 4,

    /// <summary>
    /// Version string.
    /// Should begin with the syntax "Version /<number/>./<number/>" and can contain additional version information.
    /// </summary>
    Version = 5,

    /// <summary>
    /// PostScript name for the font.
    /// Specifies a string used to invoke a PostScript language font that corresponds to this OpenType font.
    /// </summary>
    PostScriptName = 6,

    /// <summary>
    /// Trademark notice.
    /// </summary>
    Trademark = 7,

    /// <summary>
    /// Manufacturer Name.
    /// </summary>
    ManufacturerName = 8,

    /// <summary>
    /// Designer name of the typeface.
    /// </summary>
    DesignerName = 9,

    /// <summary>
    /// Description of the typeface.
    /// Can contain revision information, usage recommendations, history, features, etc.
    /// </summary>
    Description = 10,

    /// <summary>
    /// URL Vendor.
    /// URL of the font vendor (with protocol, e.g., http://, ftp://).
    /// </summary>
    VendorURL = 11,

    /// <summary>
    /// URL Designer.
    /// URL of the typeface designer (with protocol, e.g., http://, ftp://).
    /// </summary>
    DesignerURL = 12,

    /// <summary>
    /// License Description.
    /// Description of how the font may be legally used, or different example scenarios for licensed use.
    /// </summary>
    LicenseDescription = 13,

    /// <summary>
    /// License Info URL.
    /// URL where additional licensing information can be found.
    /// </summary>
    LicenseInfoURL = 14,

    /// <summary>
    /// Reserved.
    /// </summary>
    Reserved15 = 15,

    /// <summary>
    /// Preferred Family.
    /// The Preferred Family ID allows font designers to include preferred family/subfamily groupings.
    /// </summary>
    PreferredFamily = 16,

    /// <summary>
    /// Preferred Subfamily.
    /// The Preferred Subfamily ID allows font designers to include preferred family/subfamily groupings.
    /// </summary>
    PreferredSubfamily = 17,

    /// <summary>
    /// Compatible Full (Macintosh only).
    /// On the Macintosh, the menu name is constructed using the FOND resource.
    /// This ID can be used to provide a compatible full name different from the Full Name.
    /// </summary>
    CompatibleFullName = 18,

    /// <summary>
    /// Sample text.
    /// This can be the font name or any other text that showcases what the font looks like.
    /// </summary>
    SampleText = 19,

    /// <summary>
    /// PostScript CID findfont name.
    /// Used to invoke the font in a PostScript interpreter with the "findfont" invocation.
    /// </summary>
    // ReSharper disable once IdentifierTypo
    // ReSharper disable once InconsistentNaming
    PostScriptCIDFindfontName = 20,

    /// <summary>
    /// WWS Family Name.
    /// Used to provide a WWS-conformant family name in case the entries for IDs 16 and 17 do not conform to the WWS model.
    /// </summary>
    // ReSharper disable once IdentifierTypo
    // ReSharper disable once InconsistentNaming
    WWSFamilyName = 21,

    /// <summary>
    /// WWS Subfamily Name.
    /// Used in conjunction with ID 21, this ID provides a WWS-conformant subfamily name in case the entries for IDs 16 and 17 do not conform to the WWS model.
    /// </summary>
    // ReSharper disable once IdentifierTypo
    // ReSharper disable once InconsistentNaming
    WWSSubfamilyName = 22,

    /// <summary>
    /// Light Background Palette.
    /// This ID, if used in the CPAL table's Palette Labels Array, specifies that the corresponding color palette in the CPAL table is appropriate to use with the font when displaying it on a light background such as white.
    /// </summary>
    LightBackgroundPalette = 23,

    /// <summary>
    /// Dark Background Palette.
    /// This ID, if used in the CPAL table's Palette Labels Array, specifies that the corresponding color palette in the CPAL table is appropriate to use with the font when displaying it on a dark background such as black.
    /// </summary>
    DarkBackgroundPalette = 24,

    /// <summary>
    /// Variations PostScript Name Prefix.
    /// If present in a variable font, it may be used as the family prefix in the PostScript Name Generation for Variation Fonts algorithm.
    /// </summary>
    VariationsPostScriptNamePrefix = 25
}