using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class EquipmentsController(AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Equipment>>> GetEquipments()
    {
        return await context.Equipments.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Equipment>> GetEquipmentsDetail(string id)
    {
        var equipment = await context.Equipments.FindAsync(id);

        if (equipment == null) return NotFound();

        return equipment;
    }
}
