using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.DeleteOrder
{
    public class DeleteOrderRequestValidator : AbstractValidator<DeleteOrderRequest>
    {
        public DeleteOrderRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
