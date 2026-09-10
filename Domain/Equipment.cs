using System;

namespace Domain;

public class Equipment
{
    //'Id' as the Primary Key.
    public string Id { get; set; } = Guid.NewGuid().ToString();

    //The specific serial number on the machine ("BG10-A987")
    public required string SerialNumber { get; set; }

    //The type of scanner (e.g., "BG5030", "BG100100")
    public required string ModelType { get; set; }

    //Location of machine
    public required string Location { get; set; }

    //Machine Status : "Active", "In Repair", or "Rented"
    public required string Status { get; set; }

    //Installed DateTime of specific machine
    public DateTime DateInstalled { get; set; }

    //Note for engineers (eg. "Needs belt replacement soon")
    public string? Description { get; set; }
}
