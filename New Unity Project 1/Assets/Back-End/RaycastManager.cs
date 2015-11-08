using UnityEngine;
using System.Collections;


public class RaycastManager : MonoBehaviour {
    [SerializeField] LineRenderer line;
    RaycastHit h;



    // Use this for initialization
    void Start() {
        //line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        Ray ray = new Ray(transform.position , transform.forward);

        line.SetPosition(0 , ray.origin);
        if (Physics.Raycast(ray , out h , 50)) {
            if (h.collider.tag == "Wall") {
                line.SetPosition(1 , h.point);
            }
        }


    }

    public void toggleLaser(bool isActive) {
        if (isActive) {
            line.enabled = true;
        } else {
            line.enabled = false;
        }
    }

    public float getDist() {
        return h.distance;
    }

}
