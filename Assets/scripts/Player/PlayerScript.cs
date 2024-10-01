using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;

namespace Player
{



    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;

        public Animator anim;
        public SpriteRenderer sprite;


        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        public JumpState jumpState;

        public StateMachine sm;
        bool isGrounded;



        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            anim = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();

            sm = gameObject.AddComponent<StateMachine>();

            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);
            jumpState = new JumpState(this, sm);
            isGrounded = false;

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate(); 
            /*
             ISSUE HERE APPARENTLY??????
            "Object reference not set to an instance of an object"
            Only causes problems after jump button pressed
            all following text does not display on screen, and states can no longer be changed
             */


            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);

            UIscript.ui.DrawText(s);

            UIscript.ui.DrawText("Press arrow keys for run");

        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }



        public void CheckForRun()
        {
            if (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("a") || Input.GetKey("d")) // key held down
            {
                sm.ChangeState(runningState);
                return;
            }

        }


        public void CheckForIdle()
        {
            /*
            if (Input.GetKey("i") ) // key held down
            {
                sm.ChangeState(idleState);
            }
            */
            if (!Input.anyKey)
            {
                sm.ChangeState(idleState);
            }

        }

        public void CheckForJump()
        {
            //print("isgrounded=" + isGrounded);
            if (Input.GetKey("space") && isGrounded ) 
            {
                sm.ChangeState(jumpState); //change to jump state 
                
                return;
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if( collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = false;
            }
        }


        public void CheckForLanding()
        {
            if( isGrounded && rb.velocity.y <= 0 )
            {
                sm.ChangeState(idleState);
            }
        }



    }

}