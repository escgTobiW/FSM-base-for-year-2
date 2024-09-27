
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class RunningState : State
    {
        // constructor
        public RunningState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }
        
        
        public override void Enter()
        {
           
            base.Enter();
            player.anim.Play("playerRUN", 0, 0);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            player.CheckForIdle();
            Debug.Log("checking for idle");

            
            if (player.sprite.flipX == false && (Input.GetKey("left") || Input.GetKey("a"))) 
            {
               player.sprite.flipX = true;
            }
            else if (player.sprite.flipX == true && (Input.GetKey("right") || Input.GetKey("d")))
            {
                player.sprite.flipX = false;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}