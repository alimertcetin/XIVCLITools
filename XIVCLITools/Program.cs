using Common.Core;
using Common.Utilities;
using XIVFileFinder;

namespace XIV.CLI
{
    internal class Program
    {
        public static readonly Dictionary<string, Func<string[], int>> map = new()
        {
            ["help"] = new CommandHelper().Run,
            ["filefinder"] = new FileFinder().Run,
        };

        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Logger.LogError(new ArgumentOutOfRangeException(nameof(args), "There is no argument provided."));
                map["help"].Invoke(args);
                return -1;
            }

            var target = args[0].ToLowerInvariant();
            
            if (map.TryGetValue(target, out var func))
            {
                var arguments = ArrayUtils.RemoveAt(args, 0);
                return func.Invoke(arguments);
            }

            return map["help"].Invoke(args);
        }
    }
}