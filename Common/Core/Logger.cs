namespace Common.Core
{
    public static class Logger
    {
        public static void Log<T>(T item)
        {
            Console.WriteLine(item);
        }

        public static void LogError<T>(T item)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Log("Error : " + item);
            Console.ResetColor();
        }

        public static void LogError<T>(IList<T> errorList)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int count = errorList.Count;
            for (int i = 0; i < count; i++)
            {
                var item = errorList[i];
                Log("Error : " + item);
            }
            Console.ResetColor();
        }
        
        public static void LogList<T>(IList<T> list)
        {
            int listCount = list.Count;
            for (var i = 0; i < listCount; i++)
            {
                var item = list[i];
                Log(item);
            }
        }
        
        public static void LogList<T>(IList<T> list, Func<T, string> getStringFunc)
        {
            int listCount = list.Count;
            for (var i = 0; i < listCount; i++)
            {
                var item = list[i];
                Log(getStringFunc.Invoke(item));
            }
        }
        
        public static void LogList<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Log(item);
            }
        }
    }
}