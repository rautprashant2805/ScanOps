using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Equipments.Queries
{
    public class GetEquipmentList
    {
        public class Query : IRequest<List<Equipment>> {}

        public class Handler(AppDbContext context) : IRequestHandler<Query, List<Equipment>>
        {
            public async Task<List<Equipment>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Equipments.ToListAsync(cancellationToken);
            }
        }
    }
}