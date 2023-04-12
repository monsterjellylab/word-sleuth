using Game.Scripts.Helper;
using Logger = Game.Scripts.Helper.Logger;

namespace Game.Scripts.UI
{
    public class LoseUI : UIPage
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
    }
}