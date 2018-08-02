using System.Collections.Generic;
using Utility;
using Xunit;

namespace Test
{
    public class TextUtilsTests
    {
        [Theory]
        [InlineData("login user\"myself\" pass\"secret\" and connect", 2)]
        [InlineData("login user\"myself\" connect", 1)]
        [InlineData("login user connect", 0)]
        public void Double_Quoted_Words_Extracted(string sentence, int count)
        {
            // Arrange
            var textUtil = new TextUtil();

            // Act
            var result = textUtil.GetDoubleQuotedWords(sentence);

            // Assert
            Assert.Equal(result.Count, count);
        }

        [Fact]
        public void RemoveStopWords_Removes_Stop_Words()
        {
            // Arrange
            var textUtil = new TextUtil();

            var sentence = new List<string>() {"to", "together", "login", "username"};

            // Act
            var result = textUtil.RemoveStopWords(sentence);

            // Assert
            Assert.DoesNotContain("to", result);
            Assert.Contains("login", result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void RemoveDoubleQuotedOWrds_Removes_Double_Quoted_Words()
        {
            // Arrange
            var textUtil = new TextUtil();

            var sentence = "login user \"myself\" pass \"secret\" and connect";

            // Act
            var result = textUtil.RemoveDoubleQuotedOWrds(sentence);

            // Assert
            Assert.Equal("login user pass and connect", result);
        }
    }
}
