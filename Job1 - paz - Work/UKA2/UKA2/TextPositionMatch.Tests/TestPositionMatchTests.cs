using NUnit.Framework;
using FluentAssertions;

namespace TextPositionMatch.Tests;

public class TestPositionMatchTests
{
    TextPositionMatcher _textPositionMatcher;

    [SetUp]
    public void Setup()
    {
        _textPositionMatcher = new TextPositionMatcher();
    }

    [TestCase("How", "1")]
    //[TestCase("wood", "10,23,45,67")]
    //[TestCase("Wood", "10,23,45,67")]
    //[TestCase("oo", "11,24,46,68")]
    //[TestCase("oO", "11,24,46,68")]
    //[TestCase("?", "71")]
    public void Given_Text_And_Subtext_Find_Position_Of_Text_Method_Should_Return_The_Position_No(string subText, string expectedPositions)
    {
        var text = "How much wood would a Woodchuck chuck, if a Woodchuck could chuck wood?";

        var positions = _textPositionMatcher.FindPositionOfText(text, subText);

        positions.Should().Be(expectedPositions);
    }

    //[TestCase("wooden")]
    //[TestCase("x")]
    public void Given_Text_And_Subtext_That_Does_Not_Exist_Find_Position_Of_Text_Method_Should_Return_Empty(string subText)
    {
        var text = "How much wood would a Woodchuck chuck, if a Woodchuck could chuck wood?";
        var expectedBlankPositions = "";

        var positions = _textPositionMatcher.FindPositionOfText(text, subText);

        positions.Should().Be(expectedBlankPositions);
    }

    //[TestCase("")]
    //[TestCase(null)]
    public void Given_Text_And_Subtext_That_Does_Not_Exist_Find_Position_Of_Text_Method_Should_Return_Empty2(string subText)
    {
        var text = "How much wood would a Woodchuck chuck, if a Woodchuck could chuck wood?";
        var expectedBlankPositions = "";

        var positions = _textPositionMatcher.FindPositionOfText(text, subText);

        positions.Should().Be(expectedBlankPositions);
    }
}
