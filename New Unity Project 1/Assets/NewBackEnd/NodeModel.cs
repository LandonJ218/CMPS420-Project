using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeModel : MonoBehaviour {

    [SerializeField] protected NodeModel NorthNode;
    [SerializeField] protected NodeModel EastNode;
    [SerializeField] protected NodeModel WestNode;
    [SerializeField] protected NodeModel SouthNode;
    //Testing
    public bool hasVisited;

	// Use this for initialization
	void Start () {
        hasVisited = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public Transform GetTransform() {
        return GetComponent<Transform>();
    }

    public NodeModel GetNorth() {
        if(NorthNode != null) {
            return NorthNode;
        } else {
            return null;
        }
    }
    public NodeModel GetEast() {
        if (EastNode != null) {
            return EastNode;
        } else {
            return null;
        }
    }
    public NodeModel GetWest() {
        if (WestNode != null) {
            return WestNode;
        } else {
            return null;
        }
    }
    public NodeModel GetSouth() {
        if (SouthNode != null) {
            return SouthNode;
        } else {
            return null;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Capsule") {
            hasVisited = true;
            NewCapsuleController NCC = other.GetComponent<NewCapsuleController>();
            NCC.isAtTarget = true;
        } 
    }

}
