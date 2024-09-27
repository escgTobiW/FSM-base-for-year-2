using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class DeathState : State
    {
        // constructor
        public DeathState(PlayerScript player, StateMachine sm) : base(player, sm)
        {

        }


        public override void Enter()
        {

            base.Enter();
            player.anim.Play("playerDEATH", 0, 0);

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
            player.CheckForRun();
            Debug.Log("checking for run");



        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }

}

