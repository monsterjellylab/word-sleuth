using Game.Scripts.Helper;

namespace Game.Scripts.FSM.States
{
    public class LoseState : StateBase
    {
        protected internal LoseState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Logger.Log(LogMessage.Info, $"{this} OnEnter", logActive);
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