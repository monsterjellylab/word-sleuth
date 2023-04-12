using System.Collections.Generic;
using Game.Scripts.FSM;
using Game.Scripts.Helper;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class UIController : GenericMonoBehaviourSingleton<UIController>
    {
        // References to UI pages
        [SerializeField] private UIPage mainMenuUI;
        [SerializeField] private UIPage gameUI;
        [SerializeField] private UIPage winUI;
        [SerializeField] private UIPage loseUI;

        // Declare a variable to hold the current ui page
        private UI activeUI;

        // Declare a dictionary to hold the different pages
        private readonly Dictionary<UI, IUIPage> uiPages = new Dictionary<UI, IUIPage>();

        // Declare a action to notify ui change
        public delegate void UIChangedEventHandler(UI newUI);

        public event UIChangedEventHandler UIChanged;

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