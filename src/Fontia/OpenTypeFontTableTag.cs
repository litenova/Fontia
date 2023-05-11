namespace Fontia;

/// <summary>
/// Represents the table tags in a OpenType font.
/// </summary>
public enum OpenTypeFontTableTag : uint
{
    Cmap = 0x636D6170,
    Glyf = 0x676C7966,
    Head = 0x68656164,
    Hhea = 0x68686561,
    Hmtx = 0x686D7478,
    Loca = 0x6C6F6361,
    Maxp = 0x6D617870,
    Name = 0x6E616D65,
    Post = 0x706F7374
}