using FluentValidation;
using Backend.DTOs;

namespace Backend.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
