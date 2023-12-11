using Common.Core;

namespace XIV.CLI
{
    public class CommandHelper
    {
        public int Run(string[] args)
        {
            Logger.LogList(Program.map.Keys);
            return 0;
        }
    }
}