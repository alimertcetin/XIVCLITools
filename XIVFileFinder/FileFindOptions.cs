namespace XIVFileFinder
{
    public static class FileFindOptions
    {
        /// <summary>
        /// Returns true if <paramref name="fileInfo.Length"/> is less than <paramref name="length"/>; false otherwise
        /// </summary>
        public static bool ByLengthLess(FileInfo fileInfo, double length)
        {
            return fileInfo.Length <= length;
        }
        
        /// <summary>
        /// Returns true if <paramref name="fileInfo.Length"/> is greater than <paramref name="length"/>; false otherwise
        /// </summary>
        public static bool ByLengthGreater(FileInfo fileInfo, double length)
        {
            return fileInfo.Length >= length;
        }
    }
}