using Common.Core;

namespace XIVFileFinder
{
    public class CommandHelper
    {
        readonly CommandRunner commandRunner;

        public CommandHelper(CommandRunner commandRunner)
        {
            this.commandRunner = commandRunner;
        }
        
        public int Run(string[] args)
        {
            Logger.LogList(commandRunner.GetCommands().Keys);
            return 0;
        }
    }
}