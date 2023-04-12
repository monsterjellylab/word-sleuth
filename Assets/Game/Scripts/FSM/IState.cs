namespace Game.Scripts.FSM
{
    public interface IState
    {
        void OnEnter();
        void OnLateUpdate();
        void OnUpdate();
        void OnFixedUpdate();
        void OnExit();
    }
}