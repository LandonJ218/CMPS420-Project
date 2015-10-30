using UnityEngine;
using System.Collections;

public class CapsuleController : MonoBehaviour {
    protected CharacterController cc;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}

    public void zMov(bool isFwd, float acc) {
        if (isFwd) {
            cc.Move(transform.forward * acc);
        } else {
            cc.Move(-transform.forward * acc);
        }
    }

    public void xMov(bool isRgt, float acc) {
        if (isRgt) {
            cc.Move(transform.right * acc);
        } else {
            cc.Move(-transform.right * acc);
        }
    }
}
