using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];
        public CreateRestaurantCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Restaurant name is required.")
                .Length(3,100).WithMessage("Restaurant name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(dto => dto.Category)
           .Must(validCategories.Contains)
           .WithMessage("Invalid category. Please choose from the valid categories.");
            //.Custom((value, context) =>
            //{
            //    var isValidCategory = validCategories.Contains(value);
            //    if(!isValidCategory)
            //    {
            //        context.AddFailure("Category", "Invalid category. Please choose from the valid categories.");
            //    }
            //});

            RuleFor(x => x.ContactEmail)
                .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(x => x.ContactNumber)
                .NotEmpty().WithMessage("A valid Contact Number is required.");

            RuleFor(x => x.PostalCode)
                .Matches(@"^\d{2}-\d{3}$").WithMessage("Insert a valid postal code in the format XX-XXX!");

        }
    }
}
