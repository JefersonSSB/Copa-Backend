using CopaBackend.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CopaBackend.Service
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetTeamsAsync();
    }
}
