using System;
using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class OtherBallController : MonoBehaviour
    {
        private Ball ball; // Reference to the ball controller.
        public GameObject[] players;
        public GameObject Player;

        private Vector3 move;
        // the world-relative desired move direction, calculated from the camForward and user input.

        private Transform cam; // A reference to the main camera in the scenes transform
        private Vector3 camForward; // The current forward direction of the camera
        private bool jump; // whether the jump button is currently pressed


        private void Awake()
        {
            // Set up the reference.
            ball = GetComponent<Ball>();
            players = GameObject.FindGameObjectsWithTag("Player");
            Player = players[0];


            // get the transform of the main camera
            if (Camera.main != null)
            {
                cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
            }
        }


        private void Update()
        {
            // Get the axis and jump input.

            float h = Player.transform.position.x;
            float v = Player.transform.position.z;
            jump = false;  //other ball doesn't jump for now

            // calculate move direction
            //if (cam != null)
            //{
            // calculate camera relative direction to move:
            //    camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            //   move = (v*camForward + h*cam.right).normalized;
            //}
            //else
            //{
            // we use world-relative directions in the case of no main camera
            move = (v * Vector3.forward + h * Vector3.right).normalized;
            //}
        }


        private void FixedUpdate()
        {
            // Call the Move function of the ball controller
            ball.Move(move, jump);
            jump = false;
        }
    }
}
