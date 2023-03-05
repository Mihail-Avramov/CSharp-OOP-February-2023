namespace FootballTeamGenerator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Exceptions;

    public class Team
    {
		private string name;
        private readonly List<Player> players;

        public Team(string name)
        {
			this.Name = name;
			this.players = new List<Player>();
        }

		public string Name
		{
			get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameCannotBeNullOrWhiteSpace));
                }

                this.name = value;
            }
		}

        public int Rating
        {
            get
            {
                if (players.Any())
                {
                    return (int)Math.Round(this.players.Average(p => p.Stats),0);
                }

                return 0;
            }
        }

        public void AddPlayer(Player player) => players.Add(player);

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);

            if (player is null)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.MissingPlayerMessage, playerName, this.Name));
            }

            players.Remove(player);
        }
    }
}
