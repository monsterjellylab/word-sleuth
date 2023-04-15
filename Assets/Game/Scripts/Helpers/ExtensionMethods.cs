using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Scripts.Helpers
{
    public static class ExtensionMethods
    {
        public static GameObject FindChildGameObject(this GameObject parent, string name)
        {
            Transform[] children = parent.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in children)
            {
                if (child.name == name)
                {
                    return child.gameObject;
                }
            }

            return null;
        }

        public static bool TryToGetComponentInChildren<T>(this Transform self, out T target)
        {
            Transform[] children = self.GetComponentsInChildren<Transform>(true);

            foreach (Transform child in children)
            {
                if (child.TryGetComponent(out target))
                    return true;
            }

            target = default;

            return false;
        }

        public static T GetRandomElementFromArray<T>(this T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }

        public static string ShuffleWord(this string word)
        {
            char[] letters = word.ToCharArray();
            System.Random rng = new System.Random();
            int n = letters.Length;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (letters[k], letters[n]) = (letters[n], letters[k]);
            }

            return new string(letters);
        }
    }
}