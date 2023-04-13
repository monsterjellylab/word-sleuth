using System.Collections.Generic;
using Game.Scripts.Singletons;
using Game.Scripts.FSM.States;
using UnityEngine;
using Logger = Game.Scripts.Utils;

namespace Game.Scripts.FSM
{
    public class StateMachine : GenericMonoBehaviourSingleton<StateMachine>
    {
        [SerializeField] protected internal bool logActive = false;

        [Space]
        // Declare a variable to hold the current state
        private State currentState;

        // Declare a dictionary to hold the different states
        private readonly Dictionary<State, IState> states = new Dictionary<State, IState>();

        // Declare a action to notify state change
        public delegate void StateChangedEventHandler(State newState);

        public event StateChangedEventHandler StateChanged;

        // Start is called before the first frame update
        private void Start()
        {
            // Set the initial state to Idle
            currentState = State.MainMenu;

            // Initialize the different states
            states.Add(State.MainMenu, new MainMenuState(this));
            states.Add(State.Game, new GameState(this));
            states.Add(State.Win, new WinState(this));
            states.Add(State.Lose, new LoseState(this));

            // Call the OnEnter method of the initial state
            states[currentState].OnEnter();
        }

        // 3 Different Update for the current state

        #region Update methods

        private void LateUpdate()
        {
            states[currentState].OnLateUpdate();
        }

        private void Update()
        {
            states[currentState].OnUpdate();
        }

        private void FixedUpdate()
        {
            states[currentState].OnFixedUpdate();
        }

        #endregion

        // Change the state of the FSM
        public void ChangeState(State newState)
        {
            // Call the OnExit method of the current state
            states[currentState].OnExit();

            // Change the current state
            currentState = newState;

            // Call the OnEnter method of the new state
            states[currentState].OnEnter();

            // Call the StateChanged event
            StateChanged?.Invoke(newState);
        }
    }
}