using FluentAssertions;
using HolidaySearchApplication;

namespace UnitTests
{
    public class InputTests
    {
        [Fact]
        public void FirstInput()
        {
            var searchEngine = new HolidaySearchEngine();
            var result = searchEngine.Search(new HolidaySearchApplication.QueryModel.HolidaySearch());
            result.Success.Should().BeTrue();

        }
    }
}
