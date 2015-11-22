﻿using UnityEngine;
using System.Collections;

public class NewCapsuleController : MonoBehaviour {

    public enum direction {north, east, west, south};
    public NodeModel target;
    public float speed;

    float tolerance = .1f;

    protected CharacterController CC;

    public bool isAtTarget;

    // Use this for initialization
    void Start () {
        CC = GetComponent<CharacterController>();
        isAtTarget = false;
	}
	
	// Update is called once per frame
	void Update () {
        //if(!isAtTarget) {
        //    GoToTarget();
        //}
       // Example: Traverses from one node to another
       //Altered for new properties
       if (isAtTarget && target.isGoal == true)
        {

        }
        else if (!isAtTarget) {
            GoToTarget();
        } else { 
            if (target.GetWest() != null && target.GetWest().getProperty("HasVisited") == false)
            {
                target = target.GetWest();
            }
            else if (target.GetNorth() != null && target.GetNorth().getProperty("HasVisited") == false)
            {
                target = target.GetNorth();
            }
            else if (target.GetEast() != null && target.GetEast().getProperty("HasVisited") == false)
            {
                target = target.GetEast();
            }
            else if (target.GetSouth() != null && target.GetSouth().getProperty("HasVisited") == false)
            {
                target = target.GetSouth();
            }
            else if (target.GetWest() != null)
            {
                target = target.GetWest();
            }
            else if (target.GetNorth() != null)
            {
                target = target.GetNorth();
            }
            else if (target.GetEast() != null)
            {
                target = target.GetEast();
            }
            else if (target.GetSouth() != null)
            {
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
                target.setProperty("HasVisited" , true);
            }
        }
    }



}
