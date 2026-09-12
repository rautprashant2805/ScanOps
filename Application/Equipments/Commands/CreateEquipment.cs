using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Equipments.Commands
{
    public class CreateEquipment
    {
        public class Command : IRequest<string>
        {
            public required Equipment Equipment { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                context.Equipments.Add(request.Equipment);
                await context.SaveChangesAsync();

                return request.Equipment.Id;
            }
        }
    }
}