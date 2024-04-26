using System;
using UnityEngine;

namespace FSMTutorial {

    public class RoleEntity : MonoBehaviour {

        [SerializeField] public Animator animator;

        // ==== FSM ====
        public RoleFSMStatus fsmStatus;
        public bool idle_isEntering;

        public bool die_isEntering;
        public float die_maintainTime;

        public float standTime;

        public void Ctor() {

        }

        public void Move(float dt) {
            Vector2 moveAxis = new Vector2(Input.GetAxis("Horizontal"), 0);
            transform.position += new Vector3(moveAxis.x, 0, 0) * 5 * dt;
        }

        public void Enter_Idle() {
            fsmStatus = RoleFSMStatus.Idle;
            idle_isEntering = true;
        }

        public void Enter_Die(float die_maintainTime) {
            fsmStatus = RoleFSMStatus.Die;
            die_isEntering = true;
            this.die_maintainTime = die_maintainTime;
        }

    }

}