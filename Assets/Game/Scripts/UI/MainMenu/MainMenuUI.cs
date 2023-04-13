using Game.Scripts.FSM;
using Game.Scripts.Utils;

namespace Game.Scripts.UI.MainMenu
{
    using Enums;

    public class MainMenuUI : UIPage
    {
        public override void UpdateUI()
        {
            base.UpdateUI();
            Logger.Log(LogMessage.Info, $"{this} UpdateUI");
        }

        public override void Open()
        {
            base.Open();
            Logger.Log(LogMessage.Info, $"{this} Open");
        }

        public override void Close()
        {
            base.Close();
            Logger.Log(LogMessage.Info, $"{this} Close");
        }

        #region Button Events

        public void OnStartButtonClicked()
        {
            StateMachine.Instance.ChangeState(State.Game);
        }

        #endregion
    }
}