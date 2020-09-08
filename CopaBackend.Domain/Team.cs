using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaBackend.Domain
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int Gols { get; set; }

        public static Team New(Guid guid, string nome, string sigla, int gols)
        {
            return new Team() { Id = guid, Nome = nome, Sigla = sigla, Gols = gols };
        }

        private static Team Mach(Team team1, Team team2)
        {
            if (team1.Gols > team2.Gols)
                return team1;
            else if (team1.Gols < team2.Gols)
                return team2;
            else if (team1.Nome.Where(c => char.IsNumber(c)).Count() > 0 && team2.Nome.Where(c => char.IsNumber(c)).Count() > 0)
            {
                string teamHaveNumber1 = string.Join("", System.Text.RegularExpressions.Regex.Split(team1.Nome, @"[^\d]"));
                string teamHaveNumber2 = string.Join("", System.Text.RegularExpressions.Regex.Split(team2.Nome, @"[^\d]"));

                if (Int32.Parse(teamHaveNumber1) > Int32.Parse(teamHaveNumber2))
                    return team2;
                else
                    return team1;
            }
            else
            {
                if (string.Compare(team1.Nome, team2.Nome) < 0)
                    return team2;
                else
                    return team1;
            }
        }

        public static List<Winner> GenerateCup(List<Team> teams)
        {
            List<Winner> winners = new List<Winner>();

            if (teams.Count != 8)
                throw new Exception("O número de times recebidos é menor ou maior que 8. Deve-se passar exatamente oito times.");

            if (teams.GroupBy(a => a.Nome).Any(a => a.Count() > 1))
                throw new Exception("Os times devem ter nomes únicos.");


            //Ordenação da Lista

            List<Team> OrdenedTeam = teams.OrderBy(x => x.Nome).ToList();

            //Separação da Lista em 8 times

            Team team1 = OrdenedTeam.ElementAt(0);
            Team team2 = OrdenedTeam.ElementAt(1);
            Team team3 = OrdenedTeam.ElementAt(2);
            Team team4 = OrdenedTeam.ElementAt(3);
            Team team5 = OrdenedTeam.ElementAt(4);
            Team team6 = OrdenedTeam.ElementAt(5);
            Team team7 = OrdenedTeam.ElementAt(6);
            Team team8 = OrdenedTeam.ElementAt(7);

            //Disputa da primeira rodada

            Team WinnerPhaseOne1 = Mach(team1, team8);
            Team WinnerPhaseOne2 = Mach(team2, team7);
            Team WinnerPhaseOne3 = Mach(team3, team6);
            Team WinnerPhaseOne4 = Mach(team4, team5);

            //Disputa da segunda rodada com os ganhadores da primeira rodada

            Team WinnerPhaseTwo1 = Mach(WinnerPhaseOne1, WinnerPhaseOne4);
            Team WinnerPhaseTwo2 = Mach(WinnerPhaseOne2, WinnerPhaseOne3);

            //Disputa final com os ganhadores da segunda rodada 

            Team WinnerFinal = Mach(WinnerPhaseTwo1, WinnerPhaseTwo2);

            //Setando os ganhadores 
            if (WinnerFinal.Nome.Equals(WinnerPhaseTwo1.Nome))
            {
                winners.Add(Winner.New(WinnerPhaseTwo1.Nome, 1));
                winners.Add(Winner.New(WinnerPhaseTwo2.Nome, 2));
            }
            else
            {
                winners.Add(Winner.New(WinnerPhaseTwo2.Nome, 1));
                winners.Add(Winner.New(WinnerPhaseTwo1.Nome, 2));
            }


            return winners;

        }
    }
}
