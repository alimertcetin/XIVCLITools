using Common.Core;

namespace XIVConsoleTools
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