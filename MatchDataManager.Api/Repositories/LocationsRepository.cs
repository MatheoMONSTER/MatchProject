using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories;

public class LocationsRepository
{
    public LocationContext _locationContext;

    public LocationsRepository(LocationContext locationContext)
    {
        _locationContext = locationContext;
    }
    public void AddLocation(Location location)
    {
        if (_locationContext.Location.Any(x => x.Name == location.Name))
        {
            throw new ArgumentException("There can't be more than one location with the same name.", nameof(location));
        }

        location.Id = Guid.NewGuid();
        _locationContext.Location.Add(location);
    }

    public void DeleteLocation(Guid locationId)
    {
        var location = _locationContext.Location.FirstOrDefault(x => x.Id == locationId);
        if (location is not null)
        {
            _locationContext.Location.Remove(location);
        }
    }

    public IEnumerable<Location> GetAllLocations()
    {

        return _locationContext.Location;
    }

    public Location GetLocationById(Guid id)
    {
        return _locationContext.Location.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateLocation(Location location)
    {
        var existingLocation = _locationContext.Location.FirstOrDefault(x => x.Id == location.Id);
        if (existingLocation is null || location is null)
        {
            throw new ArgumentException("Location doesn't exist.", nameof(location));
        }

        existingLocation.City = location.City;
        existingLocation.Name = location.Name;
    }
}