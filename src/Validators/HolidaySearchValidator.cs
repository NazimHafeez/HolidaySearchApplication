using FluentValidation;
using HolidaySearchApplication.DomainModel.Flight;
using HolidaySearchApplication.QueryModel;

namespace HolidaySearchApplication.Validators
{
    public class HolidaySearchValidator : AbstractValidator<HolidaySearch>
    {
        public HolidaySearchValidator()
        {
            RuleFor(x => x.DepartingFrom).Must(x => AirportLookup.ContainsAirportCode(x)).Unless(x => string.IsNullOrEmpty(x.DepartingFrom) || x.DepartingFrom.Contains("any", StringComparison.InvariantCultureIgnoreCase)).WithMessage("DepartingFrom is not a known airport code");
            RuleFor(x => x.DepartureDate).NotEmpty().Must(x => DateOnly.TryParse(x, out _)).WithMessage("Departure date provided is not a valid date.");
            RuleFor(x => x.TravellingTo).NotEmpty().Must(x => AirportLookup.ContainsAirportCode(x)).WithMessage("TravellingTo is not a known airport code");
            RuleFor(x => x.Duration).NotEmpty().GreaterThan(0).LessThanOrEqualTo(365).WithMessage("Duration need to be between 1 and 365 days");
        }
    }
}
