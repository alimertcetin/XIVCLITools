namespace Common.Core
{
    public static class FileMover
    {
        public static List<string> MoveFiles(string newPath, List<FileInfo> matchedFiles)
        {
            List<string> errors = new List<string>();
            Directory.CreateDirectory(newPath);
            for (int i = 0; i < matchedFiles.Count; i++)
            {
                var fileName = matchedFiles[i].Name;
                try
                {
                    File.Move(matchedFiles[i].FullName, Path.Combine(newPath, fileName));
                }
                catch (Exception e)
                {
                    errors.Add(e.Message);
                }
            }

            return errors;
        }
    }
}