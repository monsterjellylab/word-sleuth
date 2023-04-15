using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class ChildrenWidthSetter : MonoBehaviour
    {
        [SerializeField] private float minWidth;
        [SerializeField] private float maxWidth;

        [SerializeField] private float spaceBetweenChildren;

        private int childCount;

        [PropertyOrder(1)] [SerializeField, ReadOnly]
        private float parentWidth;

        [PropertyOrder(1)] [SerializeField, ReadOnly]
        private RectTransform[] children;

        #region Editor

        [Button]
        [PropertyOrder(1)]
        private void SetRefs()
        {
            parentWidth = GetComponent<RectTransform>().sizeDelta.x;

            childCount = transform.childCount;

            children = new RectTransform[childCount];
            for (int i = 0; i < childCount; i++)
            {
                children[i] = transform.GetChild(i).GetComponent<RectTransform>();
            }
        }

        #endregion

        private void OnEnable()
        {
            SetRefs();

            childCount = children.Length;

            float totalSpace = spaceBetweenChildren * (childCount - 1);
            float totalWidth = totalSpace + maxWidth * childCount;

            if (totalWidth > parentWidth)
            {
                var desiredWidth = (parentWidth - totalSpace) / childCount;

                desiredWidth = Mathf.Clamp(desiredWidth, minWidth, maxWidth);
                for (var i = 0; i < children.Length; i++)
                {
                    children[i].sizeDelta = new Vector2(desiredWidth, children[i].sizeDelta.y);
                }
            }
        }
    }
}