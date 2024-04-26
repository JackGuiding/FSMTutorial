using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSMTutorial {

    public class Main : MonoBehaviour {

        [SerializeField] RoleEntity role;

        void Start() {
            role.Enter_Idle();
        }

        void Update() {
            float dt = Time.deltaTime;
            RoleFSMController.Tick(role, dt);
        }

    }
}
