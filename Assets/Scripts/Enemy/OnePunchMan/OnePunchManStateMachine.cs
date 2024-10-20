using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StatePattern.Enemy
{

    public class OnePunchManStateMachine : MonoBehaviour
    {
        private OnePunchManController owner;
        private IState currentState;
        protected Dictionary<OnePunchManStates, IState> States = new Dictionary<OnePunchManStates, IState>();

        public OnePunchManStateMachine(OnePunchManController owner)
        {
            this.owner = owner;
            CreateStates();
            SetOwner();

        }
        private void CreateStates()
        {
            States.Add(OnePunchManStates.IDLE, new IdleState(this));
            States.Add(OnePunchManStates.ROTATING, new RotatingState(this));
            States.Add(OnePunchManStates.SHOOTING, new ShootingState(this));
        }
        private void SetOwner()
        {
            foreach (IState state in States.Values)
            {
                state.Owner = owner;
            }

        }
        public void Update() => currentState?.Update();
        protected void ChangeState(IState state)
        {
            state?.OnStateExit();
            currentState = state;
            state?.OnStateEnter();
        }

        public void ChangeState(OnePunchManStates newState) => ChangeState(States[newState]);
    }
}
