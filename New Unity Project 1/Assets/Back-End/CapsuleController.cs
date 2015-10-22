using UnityEngine;
using System.Collections;

public class CapsuleController : MonoBehaviour {
    protected CharacterController cc;
    float scale = .5f;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.W)) {
            zMov(true);
        } else if (Input.GetKey(KeyCode.S)) {
            zMov(false);
        }
        if (Input.GetKey(KeyCode.D)) {
            xMov(true);
        } else if (Input.GetKey(KeyCode.A)) {
            xMov(false);
        }
    }

    void zMov(bool isFwd) {
        if (isFwd) {
            cc.Move(transform.forward * scale);
        } else {
            cc.Move(-transform.forward * scale);
        }
    }

    void xMov(bool isRgt) {
        if (isRgt) {
            cc.Move(transform.right * scale);
        } else {
            cc.Move(-transform.right * scale);
        }
    }
}
