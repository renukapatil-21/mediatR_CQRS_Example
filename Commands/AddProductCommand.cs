using MediatR;

namespace mediatRCQRS.Commands
{
    public record AddProductCommand(Product Product):IRequest<Product>;
}
