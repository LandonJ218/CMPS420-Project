using UnityEngine;
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
        if(!isAtTarget) {
            GoToTarget();
        }
       /* Example: Traverses from one node to another
       Will cause a reference error
        if (!isAtTarget && target != null) {
            GoToTarget();
        } else { 
            target = target.GetWest();
            isAtTarget = false;
        } */
	}

    void GoToTarget() {
        Transform NodePos = target.GetTransform();
        Vector3 Offset = NodePos.transform.position - transform.position;
        if(Offset.magnitude > tolerance) {
            Offset = Offset.normalized * (speed * 3);
            CC.Move(Offset*Time.deltaTime);
        }
        
    }

    void OnColliderEnter(Collider other) {
        if(other.tag == "Node") {
            isAtTarget = true;
        }
    }



}
