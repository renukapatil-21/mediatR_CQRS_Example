using MediatR;

namespace mediatRCQRS.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
    
}
