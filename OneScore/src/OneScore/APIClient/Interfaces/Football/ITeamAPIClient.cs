using OneScore.Models.Football;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneScore.APIClient.Interfaces.Football
{
    public interface ITeamAPIClient
    {
        Task<List<Team>> GetTeams(string CompetitionId);
    }
}
