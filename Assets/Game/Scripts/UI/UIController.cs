using System.Collections.Generic;
using Game.Scripts.FSM;
using Game.Scripts.Helpers;
using Game.Scripts.Singletons;
using Game.Scripts.UI.Game;
using Game.Scripts.UI.Interfaces;
using Game.Scripts.UI.Lose;
using Game.Scripts.UI.MainMenu;
using Game.Scripts.UI.Win;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.UI
{
    using Enums;
    public class UIController : GenericMonoBehaviourSingleton<UIController>
    {
        // References to UI pages
        [PropertyOrder(1)] [SerializeField, ReadOnly]
        private UIPage mainMenuUI;

        [PropertyOrder(1)] [SerializeField, ReadOnly]
        private UIPage gameUI;

        [PropertyOrder(1)] [SerializeField, ReadOnly]
        private UIPage winUI;

        [PropertyOrder(1)] [SerializeField, ReadOnly]
        private UIPage loseUI;

        // Declare a variable to hold the current ui page
        private UI activeUI;

        // Declare a dictionary to hold the different pages
        private readonly Dictionary<UI, IUIPage> uiPages = new Dictionary<UI, IUIPage>();

        // Declare a action to notify ui change
        public delegate void UIChangedEventHandler(UI newUI);

        public event UIChangedEventHandler UIChanged;

        #region Editor

        [PropertyOrder(1)]
        [Button]
        private void SetRefs()
        {
            if (transform.TryToGetComponentInChildren(out MainMenuUI mainMenuUI))
                this.mainMenuUI = mainMenuUI;
            if (transform.TryToGetComponentInChildren(out GameUI gameUI))
                this.gameUI = gameUI;
            if (transform.TryToGetComponentInChildren(out WinUI winUI))
                this.winUI = winUI;
            if (transform.TryToGetComponentInChildren(out LoseUI loseUI))
                this.loseUI = loseUI;
        }

        #endregion

        private void Start()
        {
            // Set the initial ui to MainMenu
            activeUI = UI.MainMenu;

            // Initialize the different ui pages
            uiPages.Add(UI.MainMenu, mainMenuUI);
            uiPages.Add(UI.Game, gameUI);
            uiPages.Add(UI.Win, winUI);
            uiPages.Add(UI.Lose, loseUI);

            // Inject UIController to all ui pages
            mainMenuUI.InjectUIController(this);
            gameUI.InjectUIController(this);
            winUI.InjectUIController(this);
            loseUI.InjectUIController(this);

            // Close all UI Pages
            foreach (var keyValuePair in uiPages)
            {
                keyValuePair.Value.Close();
            }

            // Call the Open method of the initial ui
            uiPages[activeUI].Open();
        }

        private void OnEnable()
        {
            StateMachine.Instance.StateChanged += onStateChanged;
        }

        private void OnDisable()
        {
            StateMachine.Instance.StateChanged -= onStateChanged;
        }

        public void ChangeUI(UI ui)
        {
            // Call the Close method of the current ui
            uiPages[activeUI].Close();

            // Change the current ui
            activeUI = ui;

            // Call the Open method of the new ui
            uiPages[activeUI].Open();

            // Call the UIChanged event
            UIChanged?.Invoke(ui);
        }

        private void onStateChanged(State newState)
        {
            switch (newState)
            {
                case State.MainMenu:
                    ChangeUI(UI.MainMenu);
                    break;
                case State.Game:
                    ChangeUI(UI.Game);
                    break;
                case State.Win:
                    ChangeUI(UI.Win);
                    break;
                case State.Lose:
                    ChangeUI(UI.Lose);
                    break;
            }
        }
    }
}