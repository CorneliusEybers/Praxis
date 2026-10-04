using NUnit.Framework;
using Praxis.Domain.Entities;

namespace Praxis.Tests.Domain;

[TestFixture]
public class EventTests
{
    [Test]
    public void Constructor_WhenEndIsBeforeBegin_ShouldThrowArgumentException()
    {
        // Arrange
        var begin = new DateTime(2026, 10, 4, 10, 0, 0);
        var end = new DateTime(2026, 10, 4, 9, 0, 0);       // - End is before Begin

        // Act
        var exception = Assert.Throws<ArgumentException>(() => new Event("Consultation",
                                                                         "General consultation",
                                                                         begin,
                                                                         end,
                                                                         1,
                                                                         "UNIT TEST"));

        // Assert
        Assert.That(exception!.Message,
                    Does.Contain("Event end time must be after the begin time"));
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    [TestCase("\t")]
    [TestCase("\r\n")]
    public void Constructor_WhenTitleIsNullOrWhitespace_ShouldThrowArgumentException(string? title)
    {
        // Arrange
        var begin = new DateTime(2026, 10, 4, 10, 0, 0);
        var end = new DateTime(2026, 10, 4, 11, 0, 0);

        // Act
        var exception = Assert.Throws<ArgumentException>(() => new Event(title!,
                                                                         "General consultation",
                                                                         begin,
                                                                         end,
                                                                         1,
                                                                         "UNIT TEST"));

        // Assert
        Assert.That(exception.Message,
                    Does.Contain("Event title is required"));
    }
}