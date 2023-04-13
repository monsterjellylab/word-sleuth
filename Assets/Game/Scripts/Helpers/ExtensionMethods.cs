﻿using UnityEngine;

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
    }
}