using System;
using Application.Equipments.Commands;
using Application.Equipments.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

namespace API.Controllers;

public class EquipmentsController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Equipment>>> GetEquipments()
    {
        return await Mediator.Send(new GetEquipmentList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Equipment>> GetEquipmentsDetail(string id)
    {
        return await Mediator.Send(new GetEquipmentDetails.Query{Id = id});
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateEquipment(Equipment equipment)
    {
        return await Mediator.Send(new CreateEquipment.Command{Equipment = equipment});
    }

    [HttpPut]
    public async Task<ActionResult> EditEquipment(Equipment equipment)
    {
        await Mediator.Send(new EditEquipment.Command{Equipment = equipment});
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEquipment(string id)
    {
        await Mediator.Send(new DeleteEquipment.Command{Id = id});

        return Ok();
    }
}
