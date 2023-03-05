using FootballTeamGenerator.Models.Exceptions;

namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArguments = input.Split(";");

                string command = commandArguments[0];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            AddTeam(commandArguments[1], teams);
                            break;
                        case "Add":
                            AddPlayer(
                                commandArguments[1],
                                commandArguments[2],
                                int.Parse(commandArguments[3]),
                                int.Parse(commandArguments[4]),
                                int.Parse(commandArguments[5]),
                                int.Parse(commandArguments[6]),
                                int.Parse(commandArguments[7]),
                                teams);
                            break;
                        case "Remove":
                            RemovePlayer(commandArguments[1], commandArguments[2], teams);
                            break;
                        case "Rating":
                            PrintRating(commandArguments[1], teams);
                            break;
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            static void AddTeam(string name, List<Team> teams)
            {
                teams.Add(new Team(name));
            }

            static void AddPlayer(
                string teamName,
                string name,
                int endurance,
                int sprint,
                int dribble,
                int passing,
                int shooting,
                List<Team> teams)
            {
                Team team = teams.FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InexistingTeamMessage, teamName));
                }

                Player player = new(name, endurance, sprint, dribble, passing, shooting);
                team.AddPlayer(player);
            }

            static void RemovePlayer(string teamName, string playerName, List<Team> teams)
            {
                Team team = teams.FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InexistingTeamMessage, teamName));
                }

                team.RemovePlayer(playerName);
            }

            static void PrintRating(string teamName, List<Team> teams)
            {
                Team team = teams.FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InexistingTeamMessage, teamName));
                }

                Console.WriteLine($"{teamName} - {team.Rating:f0}");
            }
        }
    }
}