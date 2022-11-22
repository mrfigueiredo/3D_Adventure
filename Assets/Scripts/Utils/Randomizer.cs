using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Randomizer
{
    public static class Randomizer
    {
        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static T GetRandom<T>(this T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }

        public static T GetRandomNonRepeated<T>(this List<T> list, T unique)
        {
            if (list.Count == 1)
                return unique;

            var uniqueIndex = list.FindIndex(i => i.Equals(unique));

            int index;
            do
            {
                index = Random.Range(0, list.Count);
            } while (index == uniqueIndex);

            return list[index];
        }
    }
}
