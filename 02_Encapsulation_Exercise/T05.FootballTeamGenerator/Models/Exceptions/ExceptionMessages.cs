namespace FootballTeamGenerator.Models.Exceptions
{
    public static class ExceptionMessages
    {
        public const string NameCannotBeNullOrWhiteSpace =
            "A name should not be empty.";
        public const string InvalidStatMessage =
            "{0} should be between {1} and {2}.";
        public const string MissingPlayerMessage =
            "Player {0} is not in {1} team.";
        public const string InexistingTeamMessage =
            "Team {0} does not exist.";
    }
}
