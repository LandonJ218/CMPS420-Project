using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugTool : MonoBehaviour {

    [SerializeField] protected bool debugActive;

    [SerializeField] SensorsManager sm;

    [SerializeField] protected Text nt;
    [SerializeField] protected Text et;
    [SerializeField] protected Text wt;
    [SerializeField] protected Text st;

    [SerializeField] protected Text WallAlert;
    [SerializeField] protected Text GoalAlert;

    void OnGUI() {
        if (debugActive) { 
            checkSensors();
        }

    }

    private void setTextActive(bool isActive) {
        nt.gameObject.SetActive(isActive);
        et.gameObject.SetActive(isActive);
        wt.gameObject.SetActive(isActive);
        st.gameObject.SetActive(isActive);

        WallAlert.gameObject.SetActive(isActive);
        WallAlert.gameObject.SetActive(isActive);
    }

    private void checkSensors() {
        nt.text = "North Ray distance from wall: " + sm.norDist;
        et.text = "East Ray distance from wall: " + sm.easDist;
        wt.text = "West Ray distance from wall: " + sm.wesDist;
        st.text = "South Ray distance from wall: " + sm.souDist;

        if (sm.wallTripped) {
            WallAlert.text = "Wall nearby";
        } else {
            WallAlert.text = "No Walls nearby";
        }

        if (sm.goalTripped) {
            GoalAlert.text = "Goal nearby";
        } else {
            GoalAlert.text = "No Goals nearby";
        }
    }

    // Use this for initialization
    void Start () {
        setTextActive(debugActive);
        sm.toggleVis(debugActive);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
