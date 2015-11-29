﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NewCapsuleController : MonoBehaviour {

    //Movement
    public NodeModel target;
    public float speed;
    float tolerance = .1f;
    protected CharacterController CC;
    protected LogicHandler LH;
    
    //Control Vars
    public bool isAtTarget;
    public bool isTestCase;
    public bool isPlay;

    //Text
    public Text msg;

    // Use this for initialization
    void Start () {
        LH = GetComponent<LogicHandler>();
        CC = GetComponent<CharacterController>();
        isAtTarget = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        //WARNING! UNCOMMENT THE COMMENTED MESSAGE TEXT ONLY IN THE FINAL MAZE!
        if (isPlay) {
            if (isTestCase) {
                //msg.text = "Running";
                testCase();
            } else {
                //here should be a logical controller check to ensure that it does not run if the user has no instructions
                msg.text = "Running";
                if (!isAtTarget) {
                    GoToTarget();
                }
            }
            if (target.isGoal && isAtTarget) {
                isPlay = false;
                //msg.text = "You win!";
                if (!isTestCase) {
                    msg.text = "You win!";
                }

            }
        }

	}


    void testCase() {
        if (isAtTarget && target.isGoal == true) {

        } else if (!isAtTarget) {
            GoToTarget();
        } else {
            if (target.GetWest() != null && target.GetWest().getProperty("hasVisited") == false) {
                target = target.GetWest();
            } else if (target.GetNorth() != null && target.GetNorth().getProperty("hasVisited") == false) {
                target = target.GetNorth();
            } else if (target.GetEast() != null && target.GetEast().getProperty("hasVisited") == false) {
                target = target.GetEast();
            } else if (target.GetSouth() != null && target.GetSouth().getProperty("hasVisited") == false) {
                target = target.GetSouth();
            } else if (target.GetWest() != null) {
                target = target.GetWest();
            } else if (target.GetNorth() != null) {
                target = target.GetNorth();
            } else if (target.GetEast() != null) {
                target = target.GetEast();
            } else if (target.GetSouth() != null) {
                target = target.GetSouth();
            }

            isAtTarget = false;
        }
    }

    void GoToTarget() {
        Transform NodePos = target.GetTransform();
        Vector3 Offset = NodePos.transform.position - transform.position;
        if(Offset.magnitude > tolerance) {
            Offset = Offset.normalized * (speed * 3);
            CC.Move(Offset*Time.deltaTime);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Node")
        {
            if (other.gameObject.GetInstanceID() == target.gameObject.GetInstanceID())
            {
                isAtTarget = true;
                target.setProperty("hasVisited" , true);
                target.ApplyVisitMat();

                if(isTestCase) {
                    target.CheckIfDeadEnd();
                }/*else {
                    getTargetDir
                    If(INS.Order = DeadEnd) {
                        target."targetDir".deadEnd=MarkDeadEnd()
                    } else {
                        target."targetDir" = target;
                    }
                }
                */
            }
        }
    }

    public void Teleport(Transform t) {
        CC.gameObject.transform.position = t.position;
    }


}
