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

        public float xv, yv;
        public float runSpeed = 6;
        

        // variables holding the different player states
        public StandingState standingState;
        public RunningState runningState;

        public StateMachine sm;



        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sm = gameObject.AddComponent<StateMachine>();

            // add new states here
            standingState = new StandingState(this, sm);
            runningState = new RunningState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(standingState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.HandleInput();
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);
            UIscript.ui.DrawText(s);

            s = string.Format("current xv={0} yv={1}", xv, yv);
            UIscript.ui.DrawText(s);
        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
            rb.velocity = new Vector2(xv, yv);
        }



        public void CheckForRun()
        {
            if (Input.GetKey("left")) // key held down
            {
                runSpeed = -3;
                sm.ChangeState(runningState);

                return;
            }

            if (Input.GetKey("right")) // key held down
            {
                runSpeed = 3;
                sm.ChangeState(runningState);
            }
        }


        public void CheckForStand()
        {
                if (Input.GetKey("left") == false) // key held down
                {
                    if (Input.GetKey("right") == false) // key held down
                    {
                        sm.ChangeState(standingState);
                    }
                }

        }



    }

}