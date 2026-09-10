using System;
using System.Diagnostics;
using Domain;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        // Seed into database only if Database is Empty or return here
        if (context.Equipments.Any()) return;

        // Seed if Database is empty
        var equipments = new List<Equipment>
        {
            new()
            {
                SerialNumber = "BG10A",
                ModelType = "BG5050",
                Location = "Indira Gandhi International Airport, Terminal 3, Delhi",
                Status = "Active",
                DateInstalled = DateTime.UtcNow.AddMonths(-12),
                Description = "Primary baggage checkpoint. Passed last quarterly radiation and sensor check."
            },
            new()
            {
                SerialNumber = "BG10B",
                ModelType = "BG5040",
                Location = "Chhatrapati Shivaji Maharaj International Airport, Terminal 2, Mumbai",
                Status = "Active",
                DateInstalled = DateTime.UtcNow.AddMonths(-8),
                Description = "High-throughput security lane. Routine belt lubrication completed."
            },
            new()
            {
                SerialNumber = "BG10C",
                ModelType = "BG100100",
                Location = "Air Cargo Logistics Park, Chennai",
                Status = "Maintenance Required",
                DateInstalled = DateTime.UtcNow.AddMonths(-6),
                Description = "Conveyor motor shows intermittent torque lag. Replacement part ordered."
            },
            new()
            {
                SerialNumber = "BG10D",
                ModelType = "BG5050",
                Location = "Phoenix Marketcity, Pune",
                Status = "Active",
                DateInstalled = DateTime.UtcNow.AddMonths(-4),
                Description = "Installed at North Gate entrance for visitor screening."
            },
            new()
            {
                SerialNumber = "BG10E",
                ModelType = "BG5040",
                Location = "Metro Station Security Gate 2, Bengaluru",
                Status = "Active",
                DateInstalled = DateTime.UtcNow.AddMonths(-3),
                Description = "Standard operational mode. Optical emitter calibrated last month."
            },
            new()
            {
                SerialNumber = "BG11A",
                ModelType = "BG5050",
                Location = "Rajiv Gandhi International Airport, Hyderabad",
                Status = "Under Repair",
                DateInstalled = DateTime.UtcNow.AddMonths(-2),
                Description = "Display monitor signal flickering on secondary angle; technician dispatched."
            },
            new()
            {
                SerialNumber = "BG11B",
                ModelType = "BG5040",
                Location = "Convention Center Hall A, Pragati Maidan, New Delhi",
                Status = "Active",
                DateInstalled = DateTime.UtcNow.AddMonths(-1),
                Description = "Temporary deployment for upcoming security exposition."
            },
            new()
            {
                SerialNumber = "BG11C",
                ModelType = "BG100100",
                Location = "Cochin International Airport, Kochi",
                Status = "Active",
                DateInstalled = DateTime.UtcNow.AddDays(-15),
                Description = "Newly commissioned unit. Under standard 30-day initial warranty monitoring."
            },
            new()
            {
                SerialNumber = "BG11D",
                ModelType = "BG100100",
                Location = "Navi Mumbai International Airport, Cargo Terminal",
                Status = "Pending Inspection",
                DateInstalled = DateTime.UtcNow.AddDays(-3),
                Description = "Mechanical assembly complete. Awaiting final radiation safety certification."
            },
            new()
            {
                SerialNumber = "BG11E",
                ModelType = "BG5050",
                Location = "Central Railway Station, Solapur",
                Status = "Active",
                DateInstalled = DateTime.UtcNow.AddDays(-1),
                Description = "Main passenger concourse installation. Software version 2.4 flashed."
            }
        };

        context.Equipments.AddRange(equipments); //Passes all list of objects to the database context in one step
        await context.SaveChangesAsync(); //Actual database entires
    }
}
