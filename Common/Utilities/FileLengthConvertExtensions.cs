namespace Common.Utilities
{
    public static class FileLengthConvertExtensions
    {
        // https://stackoverflow.com/a/22733709
        public enum SizeUnit
        {
            Byte = 0,
            KB,
            MB,
            GB,
            TB,
            PB,
            EB,
            ZB,
            YB,
            Length,
        }

        public static string ToSizeString(this long value, SizeUnit unit)
        {
            return (value / (double)Math.Pow(1024, (Int64)unit)).ToString("0.00");
        }

        public static double ToSize(this long value, SizeUnit unit)
        {
            return (value / (double)Math.Pow(1024, (Int64)unit));
        }

        public static string ToSizeString(this double value, SizeUnit unit)
        {
            return (value / (double)Math.Pow(1024, (Int64)unit)).ToString("0.00");
        }

        public static double ToSize(this double value, SizeUnit unit)
        {
            return (value / (double)Math.Pow(1024, (Int64)unit));
        }

        public static double ToLargestSize(this double value)
        {
            value = ToSize(value, SizeUnit.Byte);
            int order = 0;
            int sizeUnitLength = (int)SizeUnit.Length;
            while (value > 1024 && order < sizeUnitLength)
            {
                order++;
                value /= 1024;
            }

            return ToSize(value, (SizeUnit)order);
        }

        public static string ToLargestSizeString(this double value)
        {
            return ToLargestSize(value).ToString("0.00");
        }

        public static double ToLargestSize(this long value, out SizeUnit closestSize)
        {
            var v = ToSize(value, SizeUnit.Byte);
            int order = 0;
            int sizeUnitLength = (int)SizeUnit.Length;
            while (v > 1024 && order < sizeUnitLength)
            {
                order++;
                v /= 1024;
            }

            closestSize = (SizeUnit)order;
            return v;
        }

        public static string ToLargestSizeString(this long value)
        {
            return ToLargestSize(value, out var sizeUnit).ToString("0.00") + sizeUnit.ToString();
        }
    }
}