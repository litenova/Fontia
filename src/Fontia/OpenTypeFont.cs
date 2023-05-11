namespace Fontia;

public class OpenTypeFont
{
    /// <summary>
    /// Gets the Copyright notice.
    /// </summary>
    public string CopyrightNotice { get; private set; }

    /// <summary>
    /// Gets the font family name.
    /// </summary>
    public string FamilyName { get; private set; }

    /// <summary>
    /// Gets the font subfamily name.
    /// </summary>
    public string SubfamilyName { get; private set; }

    /// <summary>
    /// Gets the unique identifier of the font.
    /// </summary>
    public string UniqueFontIdentifier { get; private set; }

    /// <summary>
    /// Gets the full font name including the family and subfamily names.
    /// </summary>
    public string FullName { get; private set; }

    /// <summary>
    /// Gets the version number of the font.
    /// </summary>
    public string Version { get; private set; }

    /// <summary>
    /// Gets the PostScript name of the font.
    /// </summary>
    /// <remarks>
    /// The PostScript name is an alternative name assigned to a font that is primarily used for compatibility with PostScript printers and software.
    /// It is often a simplified and unique name without spaces or special characters.
    /// </remarks>
    public string PostScriptName { get; private set; }

    /// <summary>
    /// Gets the trademark information associated with the font.
    /// </summary>
    public string Trademark { get; private set; }

    /// <summary>
    /// Gets the name of the font manufacturer.
    /// </summary>
    public string ManufacturerName { get; private set; }

    /// <summary>
    /// Gets the name of the font designer.
    /// </summary>
    public string DesignerName { get; private set; }

    /// <summary>
    /// Gets the font description or additional information.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Gets the URL of the font vendor or foundry.
    /// </summary>
    public string VendorURL { get; private set; }

    /// <summary>
    /// Gets the URL of the font designer or creator.
    /// </summary>
    public string DesignerURL { get; private set; }

    /// <summary>
    /// Gets the license description or terms of use associated with the font.
    /// </summary>
    public string LicenseDescription { get; private set; }

    /// <summary>
    /// Gets the URL or web page where the font license information can be found.
    /// </summary>
    public string LicenseURL { get; private set; }

    /// <summary>
    /// Gets the preferred family name used for font matching or substitution purposes.
    /// </summary>
    public string PreferredFamily { get; private set; }

    /// <summary>
    /// Gets the preferred subfamily name within the font family.
    /// </summary>
    public string PreferredSubfamily { get; private set; }

    public static async Task<OpenTypeFont> LoadAsync(string path)
    {
        await using var stream = new FileStream(path, FileMode.Open);

        using var binaryReader = new BinaryReader(stream);

        // Read font directory
        var openTypeFontDirectory = new OpenTypeFontTableDirectory(binaryReader);

        // Read name table
        var nameTableDirectoryRecord = openTypeFontDirectory[OpenTypeFontTableTag.Name];
        var nameTable = new OpenTypeFontNameTable(binaryReader, nameTableDirectoryRecord.Offset);

        return new OpenTypeFont
        {
            CopyrightNotice = nameTable[(ushort) OpenTypeFontNameId.CopyrightNotice].Value,
            FamilyName = nameTable[(ushort) OpenTypeFontNameId.FontFamily].Value,
            SubfamilyName = nameTable[(ushort) OpenTypeFontNameId.FontSubfamily].Value,
            UniqueFontIdentifier = nameTable[(ushort) OpenTypeFontNameId.UniqueFontIdentifier].Value,
            FullName = nameTable[(ushort) OpenTypeFontNameId.FullFontName].Value,
            Version = nameTable[(ushort) OpenTypeFontNameId.Version].Value,
            PostScriptName = nameTable[(ushort) OpenTypeFontNameId.PostScriptName].Value,
            Trademark = nameTable[(ushort) OpenTypeFontNameId.Trademark].Value,
            ManufacturerName = nameTable[(ushort) OpenTypeFontNameId.ManufacturerName].Value,
            DesignerName = nameTable[(ushort) OpenTypeFontNameId.DesignerName].Value,
            Description = nameTable[(ushort) OpenTypeFontNameId.Description].Value,
            VendorURL = nameTable[(ushort) OpenTypeFontNameId.VendorURL].Value,
            DesignerURL = nameTable[(ushort) OpenTypeFontNameId.DesignerURL].Value,
            LicenseDescription = nameTable[(ushort) OpenTypeFontNameId.LicenseDescription].Value,
            LicenseURL = nameTable[(ushort) OpenTypeFontNameId.LicenseInfoURL].Value,
            PreferredFamily = nameTable[(ushort) OpenTypeFontNameId.PreferredFamily].Value,
            PreferredSubfamily = nameTable[(ushort) OpenTypeFontNameId.PreferredSubfamily].Value
        };
    }
}