namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResponse>;
    public record DeleteBasketResponse(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");
        }
    }
    public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResponse>
    {
        public async Task<DeleteBasketResponse> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            string userName = command.UserName;
            // Here you would typically delete the shopping cart from a database or cache
            return new DeleteBasketResponse(true);
        }
    }
}
