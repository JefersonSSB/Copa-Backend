using CopaBackend.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CopaBackend.Service
{
    public class TeamService : ITeamService
    {
        private readonly string URL_ENDPOINT = "https://raw.githubusercontent.com/delsonvictor/testetecnico/master/equipes.json";
        private HttpClient client = new HttpClient();
        private HttpResponseMessage response = new HttpResponseMessage();

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            response = await client.GetAsync(URL_ENDPOINT);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<IEnumerable<Team>>();

            return null;
        }
    }
}
