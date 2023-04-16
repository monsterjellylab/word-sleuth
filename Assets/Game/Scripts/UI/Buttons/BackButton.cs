using Game.Scripts.FSM;
using Game.Scripts.UI.Interfaces;
using UnityEngine;

namespace Game.Scripts.UI.Buttons
{
    public class BackButton : MonoBehaviour, IButton
    {
        [SerializeField] private State ToState;
        public void OnButtonClicked()
        {
            StateMachine.Instance.ChangeState(ToState);
        }
    }
}