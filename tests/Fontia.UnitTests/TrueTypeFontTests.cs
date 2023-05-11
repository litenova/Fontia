using FluentAssertions;

namespace Fontia.UnitTests;

public class OpenTypeFontTests
{
    [Fact]
    public async Task extracted_info_should_be_correct()
    {
        // Arrange
        var alegreyaBoldItalicFontPath = Path.Combine("Fonts", "Alegreya", "Alegreya-Black.ttf");

        // Act
        var openTypeFont = await OpenTypeFont.LoadAsync(alegreyaBoldItalicFontPath);

        // Assert
        openTypeFont.FamilyName.Should().Be("Alegreya");
    }
}