using FluentValidation;
using Shop.Web.UseCases.Orders.Dtos;

namespace Shop.Web.UseCases.Orders.Utils.Validators;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleForEach(x => x.Items).Must(x => x.Quantity > 0);

        RuleFor(x => x.Items).Must(items => items.Select(x => x.ProductId).Distinct().Count() == items.Length);
    }
}