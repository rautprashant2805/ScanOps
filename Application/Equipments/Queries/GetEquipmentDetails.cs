using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Equipments.Queries
{
    public class GetEquipmentDetails
    {
        public class Query : IRequest<Equipment>
        {
            public required string Id { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Query, Equipment>
        {
            public async Task<Equipment> Handle(Query request, CancellationToken cancellationToken)
            {
                var equipment = await context.Equipments.FindAsync([request.Id], cancellationToken);
                
                if (equipment == null) throw new Exception("Eqquipment Not FOUND");

                return equipment;
            }
        }
    }
}