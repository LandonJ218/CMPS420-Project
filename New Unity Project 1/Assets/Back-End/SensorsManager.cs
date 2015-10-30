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

    void OnGUI() {
        float[] distances = { 0f , 0f , 0f , 0f };

        for(int i = 0; i < distances.Length; i++) {
            distances[i] = Rays.getDistances(i);
        }
        nt.text = "North Ray distance from wall: " + distances[0];
        et.text = "East Ray distance from wall: " + distances [1];
        wt.text = "West Ray distance from wall: " + distances[2];
        st.text = "South Ray distance from wall: " + distances[3];

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

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
