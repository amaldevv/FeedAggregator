using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OneScore.APIClient.Interfaces.Football;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OneScore.Controllers
{
    public class FootballController : Controller
    {

        private ITeamAPIClient _teamApiClient;

        public FootballController(ITeamAPIClient TeamClient)
        {
            _teamApiClient = TeamClient;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetTeams(string CompetitionId)
        {
            var model = await _teamApiClient.GetTeams(CompetitionId);
            return View("Teams");
        }
    }
}
