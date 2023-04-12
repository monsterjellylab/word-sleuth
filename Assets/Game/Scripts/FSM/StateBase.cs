namespace Game.Scripts.FSM
{
    public class StateBase : IState
    {
        protected readonly StateMachine stateMachine;
        protected bool logActive = true;

        protected StateBase(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            logActive = stateMachine.logActive;
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnLateUpdate()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnFixedUpdate()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}