using System;
using System.Threading;

namespace Archuniverse.Utilities
{
    public static class RandomProvider
    {
        private static readonly ThreadLocal<Random> _rng = new ThreadLocal<Random>(() => new Random());

        // Random int
        public static int Next() => _rng.Value.Next();
        public static int Next(int max) => _rng.Value.Next(max);
        public static int Next(int min, int max) => _rng.Value.Next(min, max);

        // Random double [0.0, 1.0)
        public static double NextDouble() => _rng.Value.NextDouble();

        // Random float [0.0f, 1.0f)
        public static float NextFloat() => (float)_rng.Value.NextDouble();

        // Random float in range [min, max)
        public static float NextFloat(float min, float max)
        {
            if (min > max)
                throw new ArgumentException("min must be <= max");
            return min + (float)_rng.Value.NextDouble() * (max - min);
        }

        // Random bool (50/50)
        public static bool NextBool() => _rng.Value.Next(2) == 0;

        // Weighted bool (0.0 to 1.0 chance for true)
        public static bool NextBool(double trueChance)
        {
            if (trueChance <= 0) return false;
            if (trueChance >= 1) return true;
            return _rng.Value.NextDouble() < trueChance;
        }

        // Random element from array
        public static T NextFrom<T>(T[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("Array must not be null or empty.");
            return array[_rng.Value.Next(array.Length)];
        }
    }
}
