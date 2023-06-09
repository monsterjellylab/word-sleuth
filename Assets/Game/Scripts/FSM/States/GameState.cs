﻿using Game.Scripts.Selector;
using Game.Scripts.Utils;
using Logger = Game.Scripts.Utils.Logger;

namespace Game.Scripts.FSM.States
{
    public class GameState : StateBase
    {
        protected internal GameState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Logger.Log(LogMessage.Info, $"{this} OnEnter", logActive);

            WordSelector.SelectWord("color", WordDifficulty.Easy);
        }

        public override void OnLateUpdate()
        {
            base.OnLateUpdate();

            Logger.Log(LogMessage.Info, $"{this} OnLateUpdate", logActive);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Logger.Log(LogMessage.Info, $"{this} OnUpdate", logActive);
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            Logger.Log(LogMessage.Info, $"{this} OnFixedUpdate", logActive);
        }

        public override void OnExit()
        {
            base.OnExit();
            Logger.Log(LogMessage.Info, $"{this} OnExit", logActive);
        }
    }
}