namespace Fontia;

/// <summary>
/// Represents the platform IDs used in the 'name' table.
/// </summary>
public enum PlatformId : ushort
{
    /// <summary>
    /// Unicode platform. This platform is used for strings encoded in Unicode format.
    /// </summary>
    Unicode = 0,

    /// <summary>
    /// Macintosh platform. This platform is used for strings encoded in Macintosh-specific encodings.
    /// </summary>
    Macintosh = 1,

    /// <summary>
    /// Windows platform. This platform is used for strings encoded in Windows-specific encodings.
    /// </summary>
    Windows = 3
}