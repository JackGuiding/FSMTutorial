using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSMTutorial {

    public class Main : MonoBehaviour {

        [SerializeField] RoleEntity role;

        public GameFSMStatus status;

        void Start() {

            status = GameFSMStatus.Login;

            role.Enter_Idle();

        }

        void OnGUI() {
            if (status == GameFSMStatus.Login) {
                if (GUI.Button(new Rect(100, 100, 200, 50), "Press Any Key To Start Game")) {
                    status = GameFSMStatus.Game;
                }
            } else if (status == GameFSMStatus.Game) {
                GUI.Label(new Rect(100, 100, 200, 50), role.fsmStatus.ToString());
            } else if (status == GameFSMStatus.Pause) {
                GUI.Label(new Rect(100, 100, 200, 50), "Pause");
            }
        
        }

        void Update() {
            float dt = Time.deltaTime;
            if (status == GameFSMStatus.Login) {

            } else if (status == GameFSMStatus.Game) {
                if (Input.GetKeyDown(KeyCode.Q)) {
                    status = GameFSMStatus.Pause;
                }
                RoleFSMController.Tick(role, dt);
            } else if (status == GameFSMStatus.Pause) {
                if (Input.GetKeyDown(KeyCode.Q)) {
                    status = GameFSMStatus.Game;
                }
            }
        }

    }
}
