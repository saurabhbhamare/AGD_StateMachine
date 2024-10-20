using UnityEngine;
using System.Collections;
namespace StatePattern.Enemy
{
    public class IdleState : IState
    {
        public OnePunchManController Owner { get; set; }
        private OnePunchManStateMachine stateMachine;
        public float timer;

        public IdleState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter() => ResetTimer();
        public void Update()
        {
            timer -= Time.deltaTime;
            if(timer<=0)
            {
                stateMachine.ChangeState(OnePunchManStates.ROTATING);
            }
        }
        public void OnStateExit() => timer = 0;
        public void ResetTimer()
        {
            timer = Owner.Data.IdleTime;
        }

    }

}


