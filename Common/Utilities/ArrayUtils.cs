namespace Common.Utilities
{
    public class ArrayUtils
    {
        public static T[] RemoveAt<T>(T[] arr, int index)
        {
            int length = arr.Length;
            if (length <= 1) return Array.Empty<T>();
            T[] newArr = new T[length - 1];
            for (int i = 1; i < length; i++)
            {
                newArr[i - 1] = arr[i];
            }

            return newArr;
        }
    }
}