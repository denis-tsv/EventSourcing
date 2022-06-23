using FluentValidation;
using Shop.Web.UseCases.Orders.Dtos;

namespace Shop.Web.UseCases.Orders.Utils.Validators;

public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderDtoValidator()
    {
        RuleForEach(x => x.Items)
            .Must(x => x.Quantity > 0)
            .WithMessage("Negative quantity");

        RuleFor(x => x.Items)
            .Must(items => items.Select(x => x.ProductId).Distinct().Count() == items.Length)
            .WithMessage("Duplicated product");
    }
}