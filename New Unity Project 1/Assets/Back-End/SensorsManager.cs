using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SensorsManager : MonoBehaviour {

    [SerializeField] RaycastCompassManager Rays;
    [SerializeField] PrioximitySensor Priox;

    [SerializeField] protected Text nt;
    [SerializeField] protected Text et;
    [SerializeField] protected Text wt;
    [SerializeField] protected Text st;

    [SerializeField] protected Text WallAlert;
    [SerializeField] protected Text GoalAlert;

    protected float norDist;
    protected float easDist;
    protected float wesDist;
    protected float souDist;

    protected bool wallTripped;
    protected bool goalTripped;

    void OnGUI() {
        nt.text = "North Ray distance from wall: " + norDist;
        et.text = "East Ray distance from wall: " + easDist;
        wt.text = "West Ray distance from wall: " + wesDist;
        st.text = "South Ray distance from wall: " + souDist;

        if (Priox.prioximityPing("Walls" , 1.1f)) {
            WallAlert.text = "Wall nearby";
        } else {
            WallAlert.text = "No Walls nearby";
        }

        if (Priox.prioximityPing("Goal" , 1.5f)) {
            GoalAlert.text = "Goal nearby";
        } else {
            GoalAlert.text = "No Goals nearby";
        }

    }
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
