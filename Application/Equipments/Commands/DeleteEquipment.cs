using System;
using MediatR;
using Persistence;

namespace Application.Equipments.Commands;

public class DeleteEquipment
{
    public class Command : IRequest
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var equipment = await context.Equipments
                .FindAsync([request.Id], cancellationToken) 
                ?? throw new Exception("Cannot find equipment");

            context.Remove(equipment);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
