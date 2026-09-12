using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Equipments.Commands
{
    public class EditEquipment
    {
        public class Command : IRequest
        {
            public required Equipment Equipment { get; set; }
        }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var equipment = await context.Equipments
                    .FindAsync([request.Equipment.Id], cancellationToken)
                    ?? throw new Exception("Cannot find Equipment");
                
                mapper.Map(request.Equipment, equipment);

                await context.SaveChangesAsync();
            }
        }
    }
}