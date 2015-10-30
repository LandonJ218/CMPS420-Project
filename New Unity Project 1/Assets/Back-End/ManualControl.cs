using UnityEngine;
using System.Collections;

public class ManualControl : MonoBehaviour {
    [SerializeField] protected CapsuleController capcon;
    [SerializeField] protected float acc;

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)) {
            capcon.zMov(true, acc);
        } else if (Input.GetKey(KeyCode.S)) {
            capcon.zMov(false, acc);
        }
        if (Input.GetKey(KeyCode.D)) {
            capcon.xMov(true, acc);
        } else if (Input.GetKey(KeyCode.A)) {
            capcon.xMov(false, acc);
        }
    }

    void changeAcc(float newAcc) {

    }
    
}
