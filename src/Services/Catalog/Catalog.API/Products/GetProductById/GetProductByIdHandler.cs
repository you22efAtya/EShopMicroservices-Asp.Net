namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    internal class GetProductByIdQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        async Task<GetProductByIdResult> IRequestHandler<GetProductByIdQuery, GetProductByIdResult>.Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(request.Id,cancellationToken);

            if(product is null)
            {
                throw new ProductNotFoundException(request.Id);
            }
            return new GetProductByIdResult(product);
        }
    }
}
