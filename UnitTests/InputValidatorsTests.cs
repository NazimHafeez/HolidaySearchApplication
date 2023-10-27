

using FluentAssertions;
using HolidaySearchApplication.QueryModel;
using HolidaySearchApplication.Validators;

namespace UnitTests
{
    public class InputValidatorsTests
    {

        [Theory]
        [InlineData("MAN", true)]
        [InlineData("LPA", true)]
        [InlineData("TFA", true)]
        [InlineData("PMI", true)]
        [InlineData("Any", true)]
        [InlineData("", true)]
        [InlineData("DDD", false)]
        [InlineData("LON", false)]
        public void ValidateDepartFrom(string input, bool isValid)
        {
            var validator = new HolidaySearchValidator();
            var validationResult = validator.Validate(new HolidaySearch { DepartingFrom = input, TravellingTo = "LPA", DepartureDate = "01/07/2023", Duration = 1 });
            validationResult.IsValid.Should().Be(isValid);
        }

        [Theory]
        [InlineData("01/07/2023", true)]
        [InlineData("01/12/2023", true)]
        [InlineData("15/15/2023", false)]
        [InlineData("", false)]
        [InlineData("Not A Date", false)]
        public void ValidateDepartureDate(string input, bool isValid)
        {
            var validator = new HolidaySearchValidator();
            var validationResult = validator.Validate(new HolidaySearch { DepartingFrom = "MAN", TravellingTo = "LPA", DepartureDate = input, Duration = 1 });
            validationResult.IsValid.Should().Be(isValid);
        }

        [Theory]
        [InlineData("MAN", true)]
        [InlineData("LPA", true)]
        [InlineData("TFA", true)]
        [InlineData("PMI", true)]
        [InlineData("Any", false)]
        [InlineData("", false)]
        public void ValidateTravellingTo(string input, bool isValid)
        {
            var validator = new HolidaySearchValidator();
            var validationResult = validator.Validate(new HolidaySearch { DepartingFrom = "MAN", TravellingTo = input, DepartureDate = "01/07/2023", Duration = 1 });
            validationResult.IsValid.Should().Be(isValid);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(10, true)]
        [InlineData(365, true)]
        [InlineData(465, false)]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void ValidateDuration(int input, bool isValid)
        {
            var validator = new HolidaySearchValidator();
            var validationResult = validator.Validate(new HolidaySearch { DepartingFrom = "MAN", TravellingTo = "LPA", DepartureDate = "01/07/2023", Duration = input });
            validationResult.IsValid.Should().Be(isValid);
        }
    }
}
