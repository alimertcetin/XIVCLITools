using Common.Core;
using Common.Utilities;

namespace XIVFileFinder
{
    public class FileFinderBySizeGreater
    {
        public int Run(string[] args)
        {
            if (args.Length == 0)
            {
                Logger.LogError(new ArgumentOutOfRangeException(nameof(args)));
                return -1;
            }

            if (double.TryParse(args[0], out double maxFileSizeMB) == false)
            {
                Logger.LogError(new System.FormatException("Input is not in correct format."));
                return -1;
            }

            var path = Environment.CurrentDirectory;
            var maxFileSizeByte = maxFileSizeMB * 1024 * 1024;
            var matchedFiles = FindFiles(path, p => FileFindOptions.ByLengthGreater(p, maxFileSizeByte));

            if (matchedFiles.Count <= 0)
            {
                Logger.Log("No file found larger than " + maxFileSizeMB + "MB");
                return 0;
            }
            Logger.Log("Files greater than " + maxFileSizeMB);
            Logger.LogList(matchedFiles, p => p.FullName + " | Size : " + p.Length.ToLargestSizeString());
            Logger.Log("Do you wanna move them to a folder in current directory? y/n");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Y)
            {
                var folderPath = Path.Combine(path, "Files Over " + maxFileSizeMB);
                var errors = FileMover.MoveFiles(folderPath, matchedFiles);
                if (errors.Count > 0)
                {
                    Logger.LogError(errors);
                    return -1;
                }
            }
            return 0;
        }
        
        public static List<FileInfo> FindFiles(string path, Func<FileInfo, bool> findFileFunc)
        {
            List<FileInfo> matchedFiles = new();
            string[] directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            for (int i = 0; i < directories.Length; i++)
            {
                string[] files = Directory.GetFiles(directories[i]);
                for (int j = 0; j < files.Length; j++)
                {
                    FileInfo info = new FileInfo(files[j]);
                    if (findFileFunc.Invoke(info))
                    {
                        matchedFiles.Add(info);
                    }
                }
            }

            return matchedFiles;
        }
    }
}