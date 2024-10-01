using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{

    public class JumpState : State
    {
         // constructor
            public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
            {
               
            }


        public override void Enter()
        {
            base.Enter();
            player.anim.Play("playerJUMP", 0, 0);
            player.rb.AddForce(player.rb.transform.up * 8, ForceMode2D.Impulse);
            // send player upwards

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

            player.CheckForLanding();
            //player.CheckForIdle();
            //Debug.Log("checking for idle");

            //player.CheckForRun();
            //Debug.Log("checking for run");

            // check for death here

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

    }


}
