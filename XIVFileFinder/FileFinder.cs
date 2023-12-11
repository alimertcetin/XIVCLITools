using Common.Core;
using Common.Utilities;

namespace XIVFileFinder
{
    public class FileFinder : CommandRunner
    {
        
        public FileFinder()
        {
            AddCommand("size", new FileFinderBySize().Run);
        }
        
        public int Run(string[] args)
        {
            if (args.Length == 0)
            {
                Logger.LogError(new ArgumentOutOfRangeException(nameof(args)));
                GetHelpCommand().Invoke(args);
                return -1;
            }

            var target = args[0].ToLowerInvariant();
            
            if (TryGetCommand(target, out var func))
            {
                var arguments = ArrayUtils.RemoveAt(args, 0);
                return func.Invoke(arguments);
            }

            return GetHelpCommand().Invoke(args);
        }
    }
}