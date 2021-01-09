using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Data;
namespace Project.Models
{
    public class AlienTeamsPageModel:PageModel
    {
        public List<AssignedTeamData> AssignedTeamDataList;
        public void PopulateAssignedTeamData(ProjectContext context,Alien alien)
        {
            var allTeams = context.Team;
            var alienTeams = new HashSet<int>(
            alien.AlienTeams.Select(c => c.AlienID));
            AssignedTeamDataList = new List<AssignedTeamData>();
            foreach (var cat in allTeams)
            {
                AssignedTeamDataList.Add(new AssignedTeamData
                {
                    TeamID = cat.ID,
                    Name = cat.TeamName,
                    Assigned = alienTeams.Contains(cat.ID)
                });
            }
        }
        public void UpdateAlienTeams(ProjectContext context,
 string[] selectedTeams, Alien alienToUpdate)
        {
            if (selectedTeams == null)
            {
                alienToUpdate.AlienTeams = new List<AlienTeam>();
                return;
            }
            var selectedTeamsHS = new HashSet<string>(selectedTeams);
            var alienTeams = new HashSet<int>
            (alienToUpdate.AlienTeams.Select(c => c.Team.ID));
            foreach (var cat in context.Team)
            {
                if (selectedTeamsHS.Contains(cat.ID.ToString()))
                {
                    if (!alienTeams.Contains(cat.ID))
                    {
                        alienToUpdate.AlienTeams.Add(
                        new AlienTeam
                        {
                            AlienID = alienToUpdate.ID,
                            TeamID = cat.ID
                        });
                    }
                }
                else
                {
                    if (alienTeams.Contains(cat.ID))
                    {
                        AlienTeam courseToRemove
                        = alienToUpdate
                        .AlienTeams
                        .SingleOrDefault(i => i.TeamID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
