using Game.Scripts.UI.Interfaces;
using UnityEngine;

namespace Game.Scripts.UI
{
    public abstract class UIPage : MonoBehaviour, IUIPage
    {
        protected UIController uiController;

        public void InjectUIController(UIController uiController)
        {
            this.uiController = uiController;
        }

        public virtual void UpdateUI(){}

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}