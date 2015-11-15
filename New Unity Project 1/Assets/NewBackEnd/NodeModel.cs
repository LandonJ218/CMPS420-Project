using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeModel : MonoBehaviour {

    [SerializeField] protected GameObject NorthNode;
    [SerializeField] protected GameObject EastNode;
    [SerializeField] protected GameObject WestNode;
    [SerializeField] protected GameObject SouthNode;
    //Testing
    public bool hasVisited;

	// Use this for initialization
	void Start () {
        hasVisited = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject GetNorth() {
        if(NorthNode != null) {
            return NorthNode;
        } else {
            return null;
        }
    }
    public GameObject GetEast() {
        if (EastNode != null) {
            return EastNode;
        } else {
            return null;
        }
    }
    public GameObject GetWest() {
        if (NorthNode != null) {
            return WestNode;
        } else {
            return null;
        }
    }
    public GameObject GetSouth() {
        if (NorthNode != null) {
            return SouthNode;
        } else {
            return null;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Capsule") hasVisited = true;
    }

}
