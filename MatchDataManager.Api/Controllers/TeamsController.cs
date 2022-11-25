using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private TeamsRepository teamsRepository;
    public TeamsController()
    {
        this.teamsRepository = new TeamsRepository(new TeamContext());
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(teamsRepository.GetTeam());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var location = teamsRepository.GetTeamById(id);
        if (location == null)
        {
            return NotFound(location);
        }
        return Ok(location);
    }

    [HttpPost]
    public IActionResult AddTeam(Team team)
    {
        teamsRepository.AddTeam(team);
        return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateTeam(Team team)
    {
        teamsRepository.UpdateTeam(team);
        return Ok(team);
    }

    [HttpDelete("{id:guid}")]
    public ActionResult<Guid> DeleteTeam(Guid id)
    {
        teamsRepository.DeleteTeam(id);
        return NoContent();
    }
}