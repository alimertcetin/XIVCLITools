namespace XIVFileFinder
{
    public abstract class CommandRunner
    {
        Dictionary<string, Func<string[], int>> map;
        public const string HELP_COMMAND_KEY = "help";

        public CommandRunner()
        {
            map = new Dictionary<string, Func<string[], int>>();
            AddCommand(HELP_COMMAND_KEY, new CommandHelper(this).Run);
        }

        protected void AddCommand(string key, Func<string[], int> runCommandFunc)
        {
            map.Add(key, runCommandFunc);
        }

        public bool TryGetCommand(string key, out Func<string[], int> runCommandFunc)
        {
            return map.TryGetValue(key, out runCommandFunc);
        }

        public Func<string[], int> GetHelpCommand() => map[HELP_COMMAND_KEY];

        public Dictionary<string, Func<string[], int>> GetCommands() => map;
    }
}