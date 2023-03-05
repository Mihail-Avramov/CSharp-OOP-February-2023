namespace FootballTeamGenerator.Models
{
    using System;

    using Exceptions;

    public class Player
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameCannotBeNullOrWhiteSpace));
                }

                this.name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidStatMessage, nameof(this.Endurance), MinStatValue, MaxStatValue));
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidStatMessage, nameof(this.Sprint), MinStatValue, MaxStatValue));
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidStatMessage, nameof(this.Dribble), MinStatValue, MaxStatValue));
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidStatMessage, nameof(this.Passing), MinStatValue, MaxStatValue));
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage, nameof(this.Shooting), MinStatValue, MaxStatValue));
                }

                this.shooting = value;
            }
        }

        public double Stats => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;

        private bool IsStatInvalid(int value) => value is < MinStatValue or > MaxStatValue;
    }
}

