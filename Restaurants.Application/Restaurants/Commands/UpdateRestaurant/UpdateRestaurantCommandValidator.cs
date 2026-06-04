using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("Restaurant name is required.")
              .Length(3, 100).WithMessage("Restaurant name must not exceed 100 characters.");

            RuleFor(x => x.Description)
              .NotEmpty().WithMessage("Description is required.");

        }
    }
}
