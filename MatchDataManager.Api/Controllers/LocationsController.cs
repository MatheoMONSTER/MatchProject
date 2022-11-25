using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    private LocationsRepository locationsRepository;

    public LocationsController()
    {
        this.locationsRepository = new LocationsRepository(new LocationContext());
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(locationsRepository.GetAllLocations());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var location = locationsRepository.GetLocationById(id);
        if (location == null)
        {
            return NotFound();
        }
        else
            return Ok(location);
    }

    [HttpPost]
    public IActionResult AddLocation(Location location)
    {
        locationsRepository.AddLocation(location);
        return CreatedAtAction(nameof(GetById), new { id = location.Id }, location);
    }

    [HttpPut]
    public IActionResult UpdateLocation(Guid locationId, Location location)
    {
        locationsRepository.UpdateLocation(location);
        return Ok(location);
    }

    [HttpDelete("{id:guid}")]
    public ActionResult<Guid> DeleteLocation(Guid locationId)
    {
        locationsRepository.DeleteLocation(locationId);
        return NoContent();
    }
}