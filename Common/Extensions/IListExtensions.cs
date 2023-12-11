namespace Common.Extensions
{
    public static class IListExtensions
    {
        public static List<string> Join<T1, T2>(this IList<T1> list1, IList<T2> list2, Func<T1, T2, string> joinFunc)
        {
            int l1Count = list1.Count;
            int l2Count = list2.Count;
            int bigger = l1Count > l2Count ? l1Count : l2Count;
            if (bigger == 0) return null;
            var list = new List<string>();
            bool isJoinNull = joinFunc == null;
            for (int i = 0; i < bigger; i++)
            {
                var item1 = i < l1Count ? list1[i] : default;
                var item2 = i < l2Count ? list2[i] : default;
                var str = isJoinNull ? item1?.ToString() + item2?.ToString() : joinFunc.Invoke(item1, item2);
                list.Add(str);
            }

            return list;
        }
    }
}