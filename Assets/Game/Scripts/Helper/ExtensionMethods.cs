using UnityEngine;

namespace Game.Scripts.Helper
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
    }
}