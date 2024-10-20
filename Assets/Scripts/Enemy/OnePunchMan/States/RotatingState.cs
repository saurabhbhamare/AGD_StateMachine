using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatePattern.Enemy;

namespace StatePattern.Enemy
{

    public class RotatingState : IState
    {
        public OnePunchManController Owner { get; set; }
        public float targetRotation;
        private OnePunchManStateMachine stateMachine;
        public RotatingState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;
        public void OnStateEnter() => targetRotation = (Owner.Rotation.eulerAngles.y + 180) % 360;
        public void Update()
        {
            // Calculate and set the character's rotation based on the target rotation.
            Owner.SetRotation(CalculateRotation());
            if (IsRotationComplete())
                stateMachine.ChangeState(OnePunchManStates.IDLE);
        }

        public void OnStateExit() { }
        private Vector3 CalculateRotation() => Vector3.up * Mathf.MoveTowardsAngle(Owner.Rotation.eulerAngles.y, targetRotation, Owner.Data.RotationSpeed * Time.deltaTime);
        private bool IsRotationComplete() => Mathf.Abs(Mathf.Abs(Owner.Rotation.eulerAngles.y) - Mathf.Abs(targetRotation)) < Owner.Data.RotationThreshold;

    }
}
