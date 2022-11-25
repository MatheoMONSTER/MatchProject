using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories;

public class TeamsRepository
{
    public TeamContext _teamContext;

    public TeamsRepository(TeamContext teamContext)
    {
        _teamContext = teamContext;
    }

    public void AddTeam(Team team)
    {
        if (_teamContext.Team.Any(x => x.Name == team.Name))
        {
            throw new ArgumentException("There can't be more than one team with the same name.", nameof(team));
        }

        team.Id = Guid.NewGuid();
        _teamContext.Team.Add(team);
    }

    public void DeleteTeam(Guid teamId)
    {
        var team = _teamContext.Team.FirstOrDefault(x => x.Id == teamId);
        if (team is not null)
        {
            _teamContext.Team.Remove(team);
        }
    }

    public Team GetTeam()
    {
        return _teamContext.Team.FirstOrDefault();
    }

    public Team GetTeamById(Guid id)
    {
        return _teamContext.Team.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateTeam(Team team)
    {
        var existingTeam = _teamContext.Team.FirstOrDefault(x => x.Id == team.Id);
        if (existingTeam is null || team is null)
        {
            throw new ArgumentException("Team doesn't exist.", nameof(team));
        }

        existingTeam.CoachName = team.CoachName;
        existingTeam.Name = team.Name;
    }
}