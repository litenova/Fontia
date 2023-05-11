using System.Text;

namespace Fontia.DataTypes;

/// <summary>
/// Represents a Tag identifier used in the OpenType font format.
/// </summary>
/// <remarks>
/// The Tag consists of a 4-byte array where each byte represents a printable ASCII character (0x20 to 0x7E).
/// It can be interpreted as a four-character sequence and is case-sensitive.
/// The Tag is commonly used to identify tables, design-variation axes, scripts, language systems, features, or baselines.
/// </remarks>
public readonly struct Tag : IEquatable<Tag>
{
    private const int TagLength = 4;

    /// <summary>
    /// Initializes a new instance of the <see cref="Tag"/> struct.
    /// </summary>
    /// <param name="tag">The byte array representing the Tag value.</param>
    /// <exception cref="ArgumentException">Thrown if the provided tag array is null or has an invalid length.</exception>
    /// <exception cref="ArgumentException">Thrown if any byte in the tag array is outside the range 0x20 to 0x7E.</exception>
    /// <exception cref="ArgumentException">Thrown if the tag contains a space character followed by a non-space character.</exception>
    public Tag(byte[] tag)
    {
        if (tag == null || tag.Length != TagLength)
        {
            throw new ArgumentException($"Invalid Tag length. Expected {TagLength} bytes.");
        }

        if (!IsValidTagBytes(tag))
        {
            throw new ArgumentException("Invalid Tag value. Each byte must be in the range 0x20 to 0x7E and not followed by a space character.");
        }

        Bytes = tag;
    }

    /// <summary>
    /// Gets the byte array representing the Tag value.
    /// </summary>
    public byte[] Bytes { get; }

    /// <inheritdoc />
    /// <summary>
    /// Returns a string that represents the current Tag.
    /// </summary>
    /// <returns>A string representation of the Tag.</returns>
    public override string ToString()
    {
        return Encoding.UTF8.GetString(Bytes);
    }

    /// <summary>
    /// Determines whether the provided byte array is a valid Tag value.
    /// </summary>
    /// <param name="tag">The byte array representing the Tag value.</param>
    /// <returns><c>true</c> if the Tag is valid; otherwise, <c>false</c>.</returns>
    private static bool IsValidTagBytes(byte[] tag)
    {
        for (var i = 0; i < tag.Length; i++)
        {
            var currentByte = tag[i];
            if (currentByte < 0x20 || currentByte > 0x7E)
            {
                return false;
            }

            if (i > 0 && currentByte == 0x20 && tag[i - 1] == 0x20)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Implicitly converts a Tag to a byte array.
    /// </summary>
    /// <param name="tag">The Tag to convert.</param>
    /// <returns>The byte array representation of the Tag.</returns>
    public static implicit operator byte[](Tag tag)
    {
        return tag.Bytes;
    }

    /// <summary>
    /// Explicitly converts a byte array to a Tag.
    /// </summary>
    /// <param name="bytes">The byte array to convert.</param>
    /// <returns>The Tag representation of the byte array.</returns>
    /// <exception cref="ArgumentException">Thrown if the provided byte array is null or has an invalid length.</exception>
    public static explicit operator Tag(byte[] bytes)
    {
        return new Tag(bytes);
    }

    /// <summary>
    /// Determines whether the current Tag is equal to another Tag.
    /// </summary>
    /// <param name="other">The Tag to compare with the current Tag.</param>
    /// <returns><c>true</c> if the current Tag is equal to the other Tag; otherwise, <c>false</c>.</returns>
    public bool Equals(Tag other)
    {
        if (Bytes.Length != other.Bytes.Length) return false;

        for (var i = 0; i < Bytes.Length; i++)
        {
            if (Bytes[i] != other.Bytes[i]) return false;
        }

        return true;
    }

    /// <inheritdoc />
    /// <summary>
    /// Determines whether the current Tag is equal to another object.
    /// </summary>
    /// <param name="obj">The object to compare with the current Tag.</param>
    /// <returns><c>true</c> if the current Tag is equal to the other object; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        return obj is Tag other && Equals(other);
    }

    /// <inheritdoc />
    /// <summary>
    /// Serves as the default hash function for the Tag.
    /// </summary>
    /// <returns>A hash code for the current Tag.</returns>
    public override int GetHashCode()
    {
        unchecked
        {
            return Bytes.Aggregate(17, (current, t) => current * 23 + t);
        }
    }

    /// <summary>
    /// Determines whether two Tag instances are equal.
    /// </summary>
    /// <param name="tag1">The first Tag to compare.</param>
    /// <param name="tag2">The second Tag to compare.</param>
    /// <returns><c>true</c> if the two Tag instances are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Tag tag1, Tag tag2)
    {
        return tag1.Equals(tag2);
    }

    /// <summary>
    /// Determines whether two Tag instances are not equal.
    /// </summary>
    /// <param name="tag1">The first Tag to compare.</param>
    /// <param name="tag2">The second Tag to compare.</param>
    /// <returns><c>true</c> if the two Tag instances are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Tag tag1, Tag tag2)
    {
        return !(tag1 == tag2);
    }
}