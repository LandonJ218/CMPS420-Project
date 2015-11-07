using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SensorsManager : MonoBehaviour {

    [SerializeField] protected RaycastCompassManager Rays;
    [SerializeField] protected PrioximitySensor Priox;

    public float norDist { get; set; }
    public float easDist { get; set; }
    public float wesDist { get; set; }
    public float souDist { get; set; }

    public bool wallTripped { get; private set; }
    public bool goalTripped { get; private set; }

    //Physics
    void FixedUpdate () {
        getRays();
        getPriox();
    }

    void getRays() {
        norDist = Rays.getDistances(0);
        easDist = Rays.getDistances(1);
        wesDist = Rays.getDistances(2);
        souDist = Rays.getDistances(3);
    }

    void getPriox() {
        if (Priox.prioximityPing("Walls" , 1.1f)) {
            wallTripped = true;
        } else {
            wallTripped = false;
        }

        if (Priox.prioximityPing("Goal" , 1.5f)) {
            goalTripped = true;
        } else {
            goalTripped = false;
        }
    }

    public void toggleVis(bool visActive) {
        Rays.toggleLasers(visActive);
    }

    // Use this for initialization
    void Start() {
        wallTripped = false;
        goalTripped = false;

        norDist = 0f;
        easDist = 0f;
        wesDist = 0f;
        souDist = 0f;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
