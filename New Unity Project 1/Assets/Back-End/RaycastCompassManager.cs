using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RaycastCompassManager : MonoBehaviour {
    //As a note, I use the Mnemonic "NEWS" to remember my compass directions when I first learned it so it stuck with me

    [SerializeField] protected RaycastManager NRay;
    [SerializeField] protected RaycastManager ERay;
    [SerializeField] protected RaycastManager WRay;
    [SerializeField] protected RaycastManager SRay;

    [SerializeField] protected Text nt;
    [SerializeField] protected Text et;
    [SerializeField] protected Text wt;
    [SerializeField] protected Text st;

    void OnGUI() {
        float len = NRay.getDist();
        nt.text = "North Ray distance from wall: " + len;

        len = ERay.getDist();
        et.text = "East Ray distance from wall: " + len;

        len = WRay.getDist();
        wt.text = "West Ray distance from wall: " + len;

        len = SRay.getDist();
        st.text = "South Ray distance from wall: " + len;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
