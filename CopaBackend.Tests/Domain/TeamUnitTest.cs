using CopaBackend.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CopaBackend.Tests.Domain
{
    public class TeamUnitTest
    {
        [Fact(DisplayName = "Verifica se o número de times recebidos é igual a 8 - Exception")]
        public void Team_ShouldOnlyAcceptEightTeams_Exception()
        {
            var teams = new List<Team>();

            for (int i = 1; i <= 10; i++)
                teams.Add(Team.New(Guid.NewGuid(), $"Team{i}", $"T{i}", i));

            var ex = Assert.Throws<Exception>(() => Team.GenerateCup(teams));
            Assert.Equal("O número de times recebidos é menor ou maior que 8. Deve-se passar exatamente oito times.", ex.Message);
        }

        [Fact(DisplayName = "Verifica se o número de times recebidos é igual a 8 - Sucesso")]
        public void Team_ShouldOnlyAcceptEightTeams_Success()
        {
            var teams = new List<Team>();

            for (int i = 1; i <= 8; i++)
                teams.Add(Team.New(Guid.NewGuid(), $"Team{i}", $"T{i}", i));

            var result = Team.GenerateCup(teams);

            Assert.Equal(2, result.Count);
        }

        [Fact(DisplayName = "Verifica se os times recebidos não possuem nenhum nome repetido - Exception")]
        public void Team_ShouldOnlyAcceptUniqueNameTeams_Exception()
        {
            var teams = new List<Team>();

            teams.Add(Team.New(Guid.NewGuid(), $"Team1", $"T1", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team2", $"T2", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team2", $"T2", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team3", $"T3", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team4", $"T4", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team5", $"T5", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team6", $"T6", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team7", $"T7", 1));

            var ex = Assert.Throws<Exception>(() => Team.GenerateCup(teams));
            Assert.Equal("Os times devem ter nomes únicos.", ex.Message);
        }

        [Fact(DisplayName = "Verifica se os times recebidos não possuem nenhum nome repetido - Sucesso")]
        public void Team_ShouldOnlyAcceptUniqueNameTeams_Success()
        {
            var teams = new List<Team>();

            teams.Add(Team.New(Guid.NewGuid(), $"Team1", $"T1", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team2", $"T2", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team3", $"T3", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team4", $"T4", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team5", $"T5", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team6", $"T6", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team7", $"T7", 1));
            teams.Add(Team.New(Guid.NewGuid(), $"Team8", $"T8", 1));

            var result = Team.GenerateCup(teams);

            Assert.Equal(2, result.Count);
        }
    }
}
