using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCommunicator.Base;
using OneScore.APIClient.Interfaces.Football;
using OneScore.Shared;
using OneScore.Models.Football;
using Newtonsoft.Json.Linq;

namespace OneScore.APIClient.Football
{
    public class TeamAPIClient:APIWrapperBase,ITeamAPIClient
    {
        public TeamAPIClient() : base(Utility.FootballDataApiUrl)
        { }

        public TeamAPIClient(string APIUrl) : base(APIUrl)
        {
        }

        public async Task<List<Team>> GetTeams(string CompetitionId)
        {
            var retJToken = await Execute<JToken>("/soccerseasons/"+ CompetitionId + "/teams");

            return new List<Team>();
        }
    }
}
