
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
            //Debug.Log("checking for idle");

            player.CheckForJump();
            //Debug.Log("checking for jump");

            if (Input.GetKey("left") || Input.GetKey("a"))
            {
                //move left
                player.sprite.flipX = true;
                Debug.Log("GOING LEFT!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            else if (Input.GetKey("right") || Input.GetKey("d"))
            {
                //move right
                player.sprite.flipX = false;
            }

            player.rb.velocity = new Vector2(2, 0);

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}