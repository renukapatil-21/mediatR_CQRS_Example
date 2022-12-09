using MediatR;

namespace mediatRCQRS.Queries
{
    
        public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
    
}
