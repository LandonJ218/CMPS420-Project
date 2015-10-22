using UnityEngine;
using System.Collections;

public class RaycastManager : MonoBehaviour {
    LineRenderer line;
    RaycastHit h;



    // Use this for initialization
    void Start () {
        line = GetComponent<LineRenderer>();

        line.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(transform.position , transform.forward);

        line.SetPosition(0 , ray.origin);
        if(Physics.Raycast(ray, out h, 50)) {
            if(h.collider.tag == "Wall") {
                line.SetPosition(1 , h.point);
            }
        }
        

	}
    public float getDist() {
        return h.distance;
    }

}
