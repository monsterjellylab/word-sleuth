using Game.Scripts.Selector;
using Game.Scripts.Utils;
using Sirenix.OdinInspector;
using UnityEngine;
using Logger = Game.Scripts.Utils.Logger;

namespace Game.Scripts.UI.Game
{
    public class GameUI : UIPage
    {
        [Space] [Title("Refs")] [PropertyOrder(1)] [SerializeField, ReadOnly]
        private LettersBoard lettersBoard;

        #region Editor

        [PropertyOrder(1)]
        [Button]
        private void SetRefs()
        {
            lettersBoard = GetComponentInChildren<LettersBoard>();
        }

        #endregion

        // Start initialization of board with selected word
        private void initializeLettersBoard(string selectedWord)
        {
            lettersBoard.InitializeBoard(selectedWord);
        }

        #region Inherited Methods

        public override void UpdateUI()
        {
            base.UpdateUI();
            Logger.Log(LogMessage.Info, $"{this} UpdateUI");
        }

        public override void Open()
        {
            base.Open();
            Logger.Log(LogMessage.Info, $"{this} Open");

            initializeLettersBoard(WordSelector.SelectedWord);
        }

        public override void Close()
        {
            base.Close();
            Logger.Log(LogMessage.Info, $"{this} Close");

            lettersBoard.Reset();
        }

        #endregion
    }
}