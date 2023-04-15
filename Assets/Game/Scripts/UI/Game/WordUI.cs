using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.UI.Game
{
    public class WordUI : MonoBehaviour
    {
        [Space] [Title("Refs")] [SerializeField, ReadOnly]
        private LetterUI[] letterUIElements;

        #region Editor

        [PropertyOrder(1)]
        [Button]
        private void SetRefs()
        {
            letterUIElements = GetComponentsInChildren<LetterUI>(true);
        }

        #endregion

        public void ConstructWord(char[] originalLetterList, char[] randomLetterList)
        {
            for (var i = 0; i < originalLetterList.Length; i++)
            {
                letterUIElements[i].gameObject.SetActive(true);
                letterUIElements[i].SetLetter(originalLetterList[i], randomLetterList[i]);
            }
        }
    }
}