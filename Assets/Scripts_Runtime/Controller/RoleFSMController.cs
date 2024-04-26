using UnityEngine;

namespace FSMTutorial {

    public static class RoleFSMController {

        public static void Tick(RoleEntity role, float dt) {
            // 有限状态机FSM(Finite State Machine): 根据不同状态执行不同逻辑
            RoleFSMStatus status = role.fsmStatus;
            if (status == RoleFSMStatus.Idle) {
                Idle_State(role, dt);
            } else if (status == RoleFSMStatus.Die) {
                Die_State(role, dt);
            } else {
                Debug.Log("ERR");
            }
            Any_State(role, dt);
        }

        static void Any_State(RoleEntity role, float dt) {
            // 任何状态都会执行的逻辑
            // role.CheckSpike(); 碰到刺死亡
            // 技能cd / Buff 时间
            float x = role.transform.position.x;
            // 超出地图边界
            if (x > 20 || x < -20) {
                if (role.fsmStatus != RoleFSMStatus.Die) {
                    role.Enter_Die(12 * 1 / 12);
                }
            }
        }

        // 状态: 空闲
        // 每个状态的三个阶段: 进入, 循环, 退出
        static void Idle_State(RoleEntity role, float dt) {

            if (role.idle_isEntering) {
                role.idle_isEntering = false;
                /* Enter: 只执行一次*/
                role.animator.Play("Idle");

                Debug.Log("Enter Idle");
            }

            // Loop, 当时要判断什么条件退出当前, 并进入下一个状态
            role.standTime += dt;
            if (role.standTime >= 5) {
                role.standTime = 0;

                // Exit: Idle
                // Enter: Die
                // role.Enter_Die(12 * 1 / 12);
            }

            role.Move(dt);
            // role.Jump();
            // role.Attack();
            // role.Falling();

        }

        // 状态: 死亡
        // 每个状态的三个阶段: 进入, 循环, 退出
        static void Die_State(RoleEntity role, float dt) {

            // Enter
            if (role.die_isEntering) {
                role.die_isEntering = false;
                role.animator.Play("Die");
                Debug.Log("Enter Die");
            }

            // Loop
            role.die_maintainTime -= dt;
            if (role.die_maintainTime <= 0) {
                // 退出
                role.transform.position = Vector3.zero;
                Debug.Log("Exit Die : " + role.transform.position);

                // Enter: Idle
                role.Enter_Idle();
            }

        }

    }
}