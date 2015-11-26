using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionPacker : MonoBehaviour {
    public Dropdown Direction;
    public Dropdown Check;
    public Text EventName;
    public InstructionsHandler IH;

    void OnGUI() {
       
    }

    public void deleteThis() {
        IH.RemoveIns(gameObject);
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
